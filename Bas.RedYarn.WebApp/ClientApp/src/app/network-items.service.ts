import { Injectable } from '@angular/core';
import { Network, DataSet, Node, Edge, IdType } from 'vis-redyarn';
import { Subject, Observable } from 'rxjs';
import { SettingsService } from './settings.service';

export class NodeLayout {

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

export class RoundNodeLayout extends NodeLayout {
  public isInActivationZone(mouseX: number, mouseY: number): boolean {
    let distance = this.distanceTo(mouseX, mouseY);
    return distance > this.settingsService.settings.ui.characterNode.radius &&
      distance <= this.settingsService.settings.ui.characterNode.radius + this.settingsService.settings.ui.newRelationship.activationZoneWidth;    
  }

  public isOverNode(mouseX: number, mouseY: number): boolean {
    return this.distanceTo(mouseX, mouseY) <= this.settingsService.settings.ui.characterNode.radius;
  }
}

export class RectangularNodeLayout extends NodeLayout {
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

@Injectable({
  providedIn: 'root'
})
export class NetworkItemsService {

  private nodeLayoutsSubject: Subject<NodeLayout> = new Subject<NodeLayout>();
  public get nodeLayoutsStream(): Observable<NodeLayout> {
    return this.nodeLayoutsSubject.asObservable();
  }

  public onUpdatedNode(node: vis.Node, boundingBox: vis.BoundingBox) {
    let width, height: number;

    let nodeLayout: NodeLayout;

    if (node.shape == "circularImage") {
      nodeLayout = new RoundNodeLayout(this.settingsService);
      width = this.settingsService.settings.ui.characterNode.radius * 2;
      height = this.settingsService.settings.ui.characterNode.radius * 2;
    } else {
      nodeLayout = new RectangularNodeLayout(this.settingsService);
      width = Math.abs(boundingBox.right - boundingBox.left);
      height = Math.abs(boundingBox.bottom - boundingBox.top);
    }

    nodeLayout.id = node.id.toString();
    nodeLayout.positionX = node.x.valueOf();
    nodeLayout.positionY = node.y.valueOf();
    nodeLayout.width = width;
    nodeLayout.height = height;

    this.nodeLayoutsSubject.next(nodeLayout);
  }

  constructor(private settingsService: SettingsService) { }
}


