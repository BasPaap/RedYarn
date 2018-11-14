import { Injectable } from '@angular/core';
import { UserInputService } from './user-input.service';
import { Node } from './diagram-types';
import { NetworkItemsService, NodeLayout } from './network-items.service';
import { SettingsService } from './settings.service';
import { DiagramDrawingService } from './diagram-drawing.service';
import { VisNetworkDirective } from './vis-network.directive';

@Injectable({
  providedIn: 'root'
})
export class NewRelationshipUIService {
  
  private nodeLayouts: { [id: string]: NodeLayout } = {};

  private visNetwork: VisNetworkDirective;

  public set network(value: VisNetworkDirective) {
    this.visNetwork = value;
  }

  constructor(private userInputService: UserInputService, private networkItemsService: NetworkItemsService, private settingsService: SettingsService, private diagramDrawingService: DiagramDrawingService) {
    this.userInputService.mouseStateStream.subscribe(mouseState => {
      if (this.visNetwork && !this.visNetwork.isDragging) {
        let [canvasX, canvasY] = this.visNetwork.getCanvasCoordinates(mouseState.xCoordinate, mouseState.yCoordinate);
        let [closestNodeLayout, distance] = this.getClosestNodeLayout(canvasX, canvasY);
        if (closestNodeLayout && this.isInActivationZone(canvasX, canvasY, closestNodeLayout)) {
          this.diagramDrawingService.drawNewRelationshipArrow(closestNodeLayout.positionX, closestNodeLayout.positionY, canvasX, canvasY);
        }
        this.visNetwork.redraw();
      }      
    });
    
    this.networkItemsService.nodeLayoutsStream.subscribe(nodeLayout => this.nodeLayouts[nodeLayout.id] = nodeLayout);
  }

  private getClosestNodeLayout(x: number, y: number): [NodeLayout, number] {
    let minDistance: number = null;
    let closestNodeLayout: NodeLayout = null;

    for (let key in this.nodeLayouts) {
      let distance = this.getDistance(x, y, this.nodeLayouts[key].positionX, this.nodeLayouts[key].positionY);
      if (minDistance === null) {
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

  private getDistance(x1: number, y1: number, x2: number, y2: number): number {
    var a = x1 - x2;
    var b = y1 - y2;
    return Math.hypot(a, b);
  }

  private isInActivationZone(x: number, y: number, nodeLayout: NodeLayout): boolean {
    let top = nodeLayout.positionY - (nodeLayout.height / 2.0) - this.settingsService.settings.ui.newRelationship.activationZoneWidth;
    let bottom = nodeLayout.positionY + (nodeLayout.height / 2.0) + this.settingsService.settings.ui.newRelationship.activationZoneWidth;
    let left = nodeLayout.positionX - (nodeLayout.width / 2.0)- this.settingsService.settings.ui.newRelationship.activationZoneWidth;
    let right = nodeLayout.positionX + (nodeLayout.width / 2.0) + this.settingsService.settings.ui.newRelationship.activationZoneWidth;

    return x >= left && x <= right && y >= top && y <= bottom;
  }
}
