import { Injectable } from '@angular/core';
import { Network, DataSet, Node, Edge, IdType } from 'vis-redyarn';
import { Subject, Observable } from 'rxjs';
import { SettingsService } from './settings.service';

export interface NodeLayout {
  id: string,
  positionX: number,
  positionY: number,
  width: number,
  height: number
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

    if (node.shape == "circularImage") {
      width = this.settingsService.settings.ui.circularImageSize * 2;
      height = this.settingsService.settings.ui.circularImageSize * 2;
    } else {
      width = Math.abs(boundingBox.right - boundingBox.left);
      height = Math.abs(boundingBox.bottom - boundingBox.top);
    }

    this.nodeLayoutsSubject.next({
      id: node.id.toString(),
      positionX: node.x.valueOf(),
      positionY: node.y.valueOf(),
      width: width,
      height: height
    });
  }

  constructor(private settingsService: SettingsService) { }
}


