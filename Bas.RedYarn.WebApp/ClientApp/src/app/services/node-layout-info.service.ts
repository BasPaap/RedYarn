import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { SettingsService } from './settings.service';

export class NodeLayoutInfo {

  constructor(protected settingsService: SettingsService) { }

  public id: string;
  public positionX: number;
  public positionY: number;
  public width: number;
  public height: number;

  public isInActivationZone(mouseX: number, mouseY: number): boolean { return false; }
  public isOverNode(mouseX: number, mouseY: number): boolean { return false; }
  public distanceTo(x: number, y: number): number {
    var a = this.positionX - x;
    var b = this.positionY - y;
    return Math.hypot(a, b);
  }

}

export class CircularNodeLayoutInfo extends NodeLayoutInfo {
  public isCircular: boolean = true;

  public isInActivationZone(mouseX: number, mouseY: number): boolean {
    let distance = this.distanceTo(mouseX, mouseY);
    return distance > this.settingsService.settings.ui.characterNode.radius &&
      distance <= this.settingsService.settings.ui.characterNode.radius + this.settingsService.settings.ui.newRelationship.activationZoneWidth;    
  }

  public isOverNode(mouseX: number, mouseY: number): boolean {
    return this.distanceTo(mouseX, mouseY) <= this.settingsService.settings.ui.characterNode.radius;
  }
}

export class RectangularNodeLayoutInfo extends NodeLayoutInfo {
  public isRectangular: boolean = true;

  public isInActivationZone(mouseX: number, mouseY: number): boolean {
    if (!this.isOverNode(mouseX, mouseY)) {
      let top = this.positionY - (this.height / 2.0) - this.settingsService.settings.ui.newRelationship.activationZoneWidth;
      let bottom = this.positionY + (this.height / 2.0) + this.settingsService.settings.ui.newRelationship.activationZoneWidth;
      let left = this.positionX - (this.width / 2.0) - this.settingsService.settings.ui.newRelationship.activationZoneWidth;
      let right = this.positionX + (this.width / 2.0) + this.settingsService.settings.ui.newRelationship.activationZoneWidth;

      return mouseX >= left && mouseX <= right && mouseY >= top && mouseY <= bottom;
    }
    else {
      return false;
    }
  }

  public isOverNode(mouseX: number, mouseY: number): boolean {
    let top = this.positionY - (this.height / 2.0);
    let bottom = this.positionY + (this.height / 2.0);
    let left = this.positionX - (this.width / 2.0);
    let right = this.positionX + (this.width / 2.0);

    return mouseX >= left && mouseX <= right && mouseY >= top && mouseY <= bottom;
  }
}

// Offers an observable with information about current node layouts
@Injectable({
  providedIn: 'root'
})
export class NodeLayoutInfoService {

  private nodeLayoutsSubject: Subject<NodeLayoutInfo> = new Subject<NodeLayoutInfo>();
  public get nodeLayoutsStream(): Observable<NodeLayoutInfo> {
    return this.nodeLayoutsSubject.asObservable();
  }

  public onUpdatedNode(node: vis.Node, boundingBox: vis.BoundingBox, x?: number, y?: number) {
    let width, height: number;

    let nodeLayout: NodeLayoutInfo;

    if (node.shape == "circularImage") {
      nodeLayout = new CircularNodeLayoutInfo(this.settingsService);
      width = this.settingsService.settings.ui.characterNode.radius * 2;
      height = this.settingsService.settings.ui.characterNode.radius * 2;
    } else {
      nodeLayout = new RectangularNodeLayoutInfo(this.settingsService);
      width = Math.abs(boundingBox.right - boundingBox.left - 12);  // Strangely, Network returns a bounding box that's 12 pixels too large for rectangular nodes.
      height = Math.abs(boundingBox.bottom - boundingBox.top - 12); // Strangely, Network returns a bounding box that's 12 pixels too large for rectangular nodes.
    }

    nodeLayout.id = node.id.toString();
    nodeLayout.positionX = x ? x : node.x.valueOf(); // The Node coordinates are not always reliable (they are not updated when dragging, for instance) so use the coordinates from the parameters if possible.
    nodeLayout.positionY = y ? y : node.y.valueOf(); // The Node coordinates are not always reliable (they are not updated when dragging, for instance) so use the coordinates from the parameters if possible.
    nodeLayout.width = width;
    nodeLayout.height = height;

    this.nodeLayoutsSubject.next(nodeLayout);
  }

  constructor(private settingsService: SettingsService) { }
}


