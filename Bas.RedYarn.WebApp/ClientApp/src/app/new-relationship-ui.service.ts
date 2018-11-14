import { Injectable } from '@angular/core';
import { UserInputService, MouseState } from './user-input.service';
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
  private isDraggingArrow: boolean = false;
  private fromNodeLayoutId: string = undefined;
  private visNetwork: VisNetworkDirective;

  public set network(value: VisNetworkDirective) {
    this.visNetwork = value;
  }

  constructor(private userInputService: UserInputService, private networkItemsService: NetworkItemsService, private settingsService: SettingsService, private diagramDrawingService: DiagramDrawingService) {
    this.userInputService.mouseStateStream.subscribe(this.onMouseState.bind(this));
    this.networkItemsService.nodeLayoutsStream.subscribe(nodeLayout => this.nodeLayouts[nodeLayout.id] = nodeLayout);
  }


  private onMouseState(mouseState: MouseState) {

    if (this.visNetwork && !this.visNetwork.isDragging) {
      let [canvasX, canvasY] = this.visNetwork.getCanvasCoordinates(mouseState.xCoordinate, mouseState.yCoordinate);
      let [closestNodeLayout, distance] = this.getClosestNodeLayout(canvasX, canvasY);

      if (closestNodeLayout && !this.visNetwork.isHoveringOverNode && this.isInActivationZone(canvasX, canvasY, closestNodeLayout)) {
        if (mouseState.isButtonDown == false) {
          this.visNetwork.isViewDraggingEnabled = false;
          this.fromNodeLayoutId = closestNodeLayout.id;
        }
      }
      else {
        if (mouseState.isButtonDown == false) {
          this.fromNodeLayoutId = undefined;
          this.visNetwork.isViewDraggingEnabled = true;
        }        
      }

      if (this.fromNodeLayoutId) {
        this.diagramDrawingService.drawNewRelationshipArrow(this.nodeLayouts[this.fromNodeLayoutId].positionX, this.nodeLayouts[this.fromNodeLayoutId].positionY, canvasX, canvasY);
      }
      
      this.visNetwork.redraw();
      
    }
  }


  private getClosestNodeLayout(x: number, y: number): [NodeLayout, number] {
    let minDistance: number = undefined;
    let closestNodeLayout: NodeLayout = undefined;

    for (let key in this.nodeLayouts) {
      let distance = this.getDistance(x, y, this.nodeLayouts[key].positionX, this.nodeLayouts[key].positionY);
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

  private getDistance(x1: number, y1: number, x2: number, y2: number): number {
    var a = x1 - x2;
    var b = y1 - y2;
    return Math.hypot(a, b);
  }

  private isInActivationZone(x: number, y: number, nodeLayout: NodeLayout): boolean {
    let top = nodeLayout.positionY - (nodeLayout.height / 2.0) - this.settingsService.settings.ui.newRelationship.activationZoneWidth;
    let bottom = nodeLayout.positionY + (nodeLayout.height / 2.0) + this.settingsService.settings.ui.newRelationship.activationZoneWidth;
    let left = nodeLayout.positionX - (nodeLayout.width / 2.0) - this.settingsService.settings.ui.newRelationship.activationZoneWidth;
    let right = nodeLayout.positionX + (nodeLayout.width / 2.0) + this.settingsService.settings.ui.newRelationship.activationZoneWidth;

    return x >= left && x <= right && y >= top && y <= bottom;
  }
}
