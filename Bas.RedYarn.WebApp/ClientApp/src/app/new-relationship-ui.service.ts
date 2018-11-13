import { Injectable } from '@angular/core';
import { UserInputService } from './user-input.service';
import { Node } from './diagram-types';
import { NetworkItemsService, NodeLayout } from './network-items.service';
import { SettingsService } from './settings.service';
import { DiagramDrawingService } from './diagram-drawing.service';

@Injectable({
  providedIn: 'root'
})
export class NewRelationshipUIService {

  private nodeLayouts: NodeLayout[] = [];

  constructor(private userInputService: UserInputService, private networkItemsService: NetworkItemsService, private settingsService: SettingsService, private diagramDrawingService: DiagramDrawingService) {
    this.userInputService.mouseStateStream.subscribe(mouseState => {
      let [closestNodeLayout, distance] = this.getClosestNodeLayout(mouseState.xCoordinate, mouseState.yCoordinate);

      if (this.isInActivationZone(mouseState.xCoordinate, mouseState.yCoordinate, closestNodeLayout)) {
        this.diagramDrawingService.drawNewRelationshipArrow(closestNodeLayout.positionX, closestNodeLayout.positionY, mouseState.xCoordinate, mouseState.yCoordinate);
      }
    });

    this.networkItemsService.nodeLayoutsStream.subscribe(nodeLayout => this.nodeLayouts.push(nodeLayout));
  }

  private getClosestNodeLayout(x: number, y: number): [NodeLayout, number] {
    let minDistance: number = null;
    let closestNodeLayout: NodeLayout = null;

    for (let nodeLayout of this.nodeLayouts) {
      let distance = this.getDistance(x, y, nodeLayout.positionX, nodeLayout.positionY);
      if (minDistance === null) {
        minDistance = distance;
        closestNodeLayout = nodeLayout;
      }
      else if (distance < minDistance) {
        minDistance = distance;
        closestNodeLayout = nodeLayout;
      }

      return [closestNodeLayout, minDistance];
    }
  }

  private getDistance(x1: number, y1: number, x2: number, y2: number): number {
    var a = x1 - x2;
    var b = y1 - y2;
    return Math.hypot(a, b);
  }

  private isInActivationZone(x: number, y: number, nodeLayout: NodeLayout): boolean {
    let top = nodeLayout.positionY - nodeLayout.height / 2.0 - this.settingsService.settings.ui.newRelationship.activationZoneWidth;
    let bottom = nodeLayout.positionY + nodeLayout.height / 2.0 + this.settingsService.settings.ui.newRelationship.activationZoneWidth;
    let left = nodeLayout.positionX - nodeLayout.width / 2.0 - this.settingsService.settings.ui.newRelationship.activationZoneWidth;
    let right = nodeLayout.positionX + nodeLayout.width / 2.0 + this.settingsService.settings.ui.newRelationship.activationZoneWidth;

    return x >= left && x <= right && y >= top && y <= bottom;
  }
}
