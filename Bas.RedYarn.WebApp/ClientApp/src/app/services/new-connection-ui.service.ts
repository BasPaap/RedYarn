import { Injectable } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { NewRelationshipDialogComponent } from '../components/new-relationship-dialog/new-relationship-dialog.component';
import { VisNetworkDirective } from '../vis-network.directive';
import { DiagramDrawingService } from './diagram-drawing.service';
import { CircularNodeLayoutInfo, NodeLayoutInfoService, NodeLayoutInfo } from './node-layout-info.service';
import { MouseState, UserInteractionService } from './user-interaction.service';
import { DiagramInfoService } from './diagram-info.service';
import { DiagramItemType } from '../diagram-types';
import { DiagramDataService } from './diagram-data.service';
import { Guid } from 'src/Guid';
import { NewCharacterPlotElementDialogComponent } from '../components/new-character-plotelement-dialog/new-character-plotelement-dialog.component';

@Injectable({
  providedIn: 'root'
})
export class NewConnectionUIService {

  private nodeLayouts: { [id: string]: NodeLayoutInfo } = {};
  private fromNodeLayoutId: string = undefined;
  private visNetwork: VisNetworkDirective;

  public set network(value: VisNetworkDirective) {
    this.visNetwork = value;
  }

  constructor(private userInteractionService: UserInteractionService, private nodeLayoutInfoService: NodeLayoutInfoService, private diagramDrawingService: DiagramDrawingService, private dialog: MatDialog, private diagramInfoService: DiagramInfoService, private diagramDataService: DiagramDataService) {
    this.userInteractionService.mouseStateStream.subscribe(this.onMouseState.bind(this));
    this.nodeLayoutInfoService.nodeLayoutsStream.subscribe(nodeLayout => this.nodeLayouts[nodeLayout.id] = nodeLayout);
  }

  private onMouseState(mouseState: MouseState) {

    if (this.visNetwork && !this.visNetwork.isDragging) {
      let [canvasX, canvasY] = this.visNetwork.getCanvasCoordinates(mouseState.x, mouseState.y);
      let [closestNodeLayout, distance] = this.getClosestNodeLayout(canvasX, canvasY);

      if (closestNodeLayout && closestNodeLayout.isInActivationZone(canvasX, canvasY)) {
        // If we're in the zone with the mouse button up, disable canvas dragging and set the from node in preparation for dragging the arrow.
        if (mouseState.isButtonDown == false) {
          this.visNetwork.isViewDraggingEnabled = false;
          this.fromNodeLayoutId = closestNodeLayout.id;
        }
      }
      else {
        // if we're not in the zone and the mouse button is up, stop dragging the arrow and enable canvas dragging.
        if (mouseState.isButtonDown == false) {
          // If there happens to be a "from" node and the mouse is over a different node, that means we've dragged the arrow from one node to another,
          // and need to create a connection. The two node types determine which type of connection that will be
          if (this.fromNodeLayoutId && closestNodeLayout.isOverNode(canvasX, canvasY) && this.fromNodeLayoutId != closestNodeLayout.id) {
            this.connectNodes(this.fromNodeLayoutId, closestNodeLayout.id);
          }

          this.fromNodeLayoutId = undefined;
          this.visNetwork.isViewDraggingEnabled = true;
        }
      }

      // If there is a "from" node, draw an arrow from that node to the destination point
      if (this.fromNodeLayoutId) {
        let [toX, toY] = this.getArrowDestination(closestNodeLayout, canvasX, canvasY);
        let fromNode = this.nodeLayouts[this.fromNodeLayoutId];
        this.diagramDrawingService.drawNewRelationshipArrow(fromNode.positionX, fromNode.positionY, toX, toY);

        // if the mouse is down, that means we're dragging the arrow, so highlight the "from" node.
        if (mouseState.isButtonDown) {
          this.highlightNode(fromNode);

          // If we're also over the closest node, then that's the "to" node, so highlight it as well.
          if (closestNodeLayout.isOverNode(canvasX, canvasY)) {
            this.highlightNode(closestNodeLayout);
          }
        }
      }

      this.visNetwork.redraw();
    }
  }

  private connectNodes(fromNodeId: string, toNodeId: string) {
    let fromType = this.diagramInfoService.getItemType(fromNodeId);
    let toType = this.diagramInfoService.getItemType(toNodeId);
    if (fromType == DiagramItemType.Character && toType == DiagramItemType.Character) {
      this.openNewRelationshipDialog(fromNodeId, toNodeId);
    }
    else if (fromType == DiagramItemType.Character && toType == DiagramItemType.Storyline) {
      this.createStorylineCharacterConnection(toNodeId, fromNodeId);
    }
    else if (fromType == DiagramItemType.Storyline && toType == DiagramItemType.Character) {
      this.createStorylineCharacterConnection(fromNodeId, toNodeId);
    }
    else if (fromType == DiagramItemType.Storyline && toType == DiagramItemType.PlotElement) {
      this.createStorylinePlotElementConnection(fromNodeId, toNodeId);
    }
    else if (fromType == DiagramItemType.PlotElement && toType == DiagramItemType.Storyline) {
      this.createStorylinePlotElementConnection(toNodeId, fromNodeId);
    }
    else if (fromType == DiagramItemType.Character && toType == DiagramItemType.PlotElement) {
      this.openNewCharacterPlotElementConnectionDialog(fromNodeId, toNodeId, false);
    }
    else if (fromType == DiagramItemType.PlotElement && toType == DiagramItemType.Character) {
      this.openNewCharacterPlotElementConnectionDialog(toNodeId, fromNodeId, true);
    }
  }

  private openNewRelationshipDialog(fromNodeId: string, toNodeId: string) {
    let dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      fromNodeId: fromNodeId,
      toNodeId: toNodeId
    };

    this.dialog.open(NewRelationshipDialogComponent, dialogConfig);
  }

  private createStorylineCharacterConnection(storylineId: string, characterId: string) {
    let connection = {
      fromNodeId: storylineId,
      toNodeId: characterId
    };

    this.diagramDataService.createStorylineCharacterConnection(connection).subscribe();
  }

  private createStorylinePlotElementConnection(storylineId: string, plotElementId: string) {
    let connection = {
      fromNodeId: storylineId,
      toNodeId: plotElementId
    };

    this.diagramDataService.createStorylinePlotElementConnection(connection).subscribe();
  }

  private openNewCharacterPlotElementConnectionDialog(characterId: string, plotElementId: string, characterOwnsPlotElement: boolean) {
    let dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      fromNodeId: characterId,
      toNodeId: plotElementId,
      characterOwnsPlotElement: characterOwnsPlotElement
    };

    this.dialog.open(NewCharacterPlotElementDialogComponent, dialogConfig);
  }

  private highlightNode(nodeLayout: NodeLayoutInfo) {
    if (this.isCircularNodeLayout(nodeLayout)) {
      this.diagramDrawingService.drawCircularNodeHighlight(nodeLayout.positionX, nodeLayout.positionY);
    }
    else {
      this.diagramDrawingService.drawRectangularNodeHighlight(nodeLayout.positionX - nodeLayout.width / 2,
        nodeLayout.positionY - nodeLayout.height / 2,
        nodeLayout.width,
        nodeLayout.height);
    }
  }

  private isCircularNodeLayout(nodeLayout: NodeLayoutInfo): nodeLayout is CircularNodeLayoutInfo {
    return (<CircularNodeLayoutInfo>nodeLayout).isCircular !== undefined;
  }

  private getArrowDestination(closestNodeLayout: NodeLayoutInfo, canvasX: number, canvasY: number): [number, number] {
    // If hovering over a node, the arrow should be drawn to the center of that node so that it "snaps" to whatever node you are hovering over.
    // if not hovering over a node, the arrow should be drawn to the cursor position.
    if (closestNodeLayout.isOverNode(canvasX, canvasY)) {
      return [closestNodeLayout.positionX, closestNodeLayout.positionY];
    }
    else {
      return [canvasX, canvasY];
    }
  }


  private getClosestNodeLayout(x: number, y: number): [NodeLayoutInfo, number] {
    let minDistance: number = undefined;
    let closestNodeLayout: NodeLayoutInfo = undefined;

    for (let key in this.nodeLayouts) {
      let distance = this.nodeLayouts[key].distanceTo(x, y);
      if (minDistance === undefined) {
        minDistance = distance;
        closestNodeLayout = this.nodeLayouts[key];
      }
      else if (distance < minDistance) {
        minDistance = distance;
        closestNodeLayout = this.nodeLayouts[key];
      }
    }

    return [closestNodeLayout, minDistance];
  }
}
