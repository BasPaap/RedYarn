import { Injectable } from '@angular/core';
import { UserInputService, MouseState } from './user-input.service';
import { Node } from './diagram-types';
import { NetworkItemsService, NodeLayout, CircularNodeLayout, RectangularNodeLayout } from './network-items.service';
import { SettingsService } from './settings.service';
import { DiagramDrawingService } from './diagram-drawing.service';
import { VisNetworkDirective } from './vis-network.directive';
import { NewRelationshipDialogComponent } from './new-relationship-dialog/new-relationship-dialog.component';
import { MatDialog } from '@angular/material';

@Injectable({
  providedIn: 'root'
})
export class NewRelationshipUIService {

  private nodeLayouts: { [id: string]: NodeLayout } = {};
  private fromNodeLayoutId: string = undefined;
  private visNetwork: VisNetworkDirective;

  public set network(value: VisNetworkDirective) {
    this.visNetwork = value;
  }

  constructor(private userInputService: UserInputService, private networkItemsService: NetworkItemsService, private diagramDrawingService: DiagramDrawingService, private dialog: MatDialog) {
    this.userInputService.mouseStateStream.subscribe(this.onMouseState.bind(this));
    this.networkItemsService.nodeLayoutsStream.subscribe(nodeLayout => this.nodeLayouts[nodeLayout.id] = nodeLayout);
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
          // and need to create a relationship.
          if (this.fromNodeLayoutId && closestNodeLayout.isOverNode(canvasX, canvasY) && this.fromNodeLayoutId != closestNodeLayout.id) {
            this.dialog.open(NewRelationshipDialogComponent);
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

  private highlightNode(nodeLayout: NodeLayout) {
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

  private isCircularNodeLayout(nodeLayout: NodeLayout): nodeLayout is CircularNodeLayout {
    return (<CircularNodeLayout>nodeLayout).isCircular !== undefined;
  }

  private getArrowDestination(closestNodeLayout: NodeLayout, canvasX: number, canvasY: number): [number, number] {
    // If hovering over a node, the arrow should be drawn to the center of that node so that it "snaps" to whatever node you are hovering over.
    // if not hovering over a node, the arrow should be drawn to the cursor position.
    if (closestNodeLayout.isOverNode(canvasX, canvasY)) {
      return [closestNodeLayout.positionX, closestNodeLayout.positionY];
    }
    else {
      return [canvasX, canvasY];
    }
  }


  private getClosestNodeLayout(x: number, y: number): [NodeLayout, number] {
    let minDistance: number = undefined;
    let closestNodeLayout: NodeLayout = undefined;

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
