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
  private _network: Network;

  public get network(): Network {
    return this.network;
  }

  public set network(networkValue: Network) {
    this._network = networkValue;
  }

  private _nodes: DataSet<Node>;
  public get nodes(): DataSet<Node> {
    return this.nodes;
  }

  public set nodes(nodesValue: DataSet<Node>) {
    if (this._nodes) {
      if (this._nodes) {
        this._nodes.off("add", this.onNodesUpdated);
        this._nodes.off("update", this.onNodesUpdated);
        this._nodes.off("remove", this.onNodesRemoved);
      }
    }

    this._nodes = nodesValue;

    if (this._nodes) {
      this._nodes.on("add", this.onNodesUpdated);
      this._nodes.on("update", this.onNodesUpdated);
      this._nodes.on("remove", this.onNodesRemoved);
    }
  }

  private _edges: DataSet<Edge>;
  public get edges(): DataSet<Edge> {
    return this.edges;
  }

  public set edges(edgesValue: DataSet<Edge>) {
    if (this._edges) {
      if (this._edges) {
        this._edges.off("add", this.onEdgesUpdated);
        this._edges.off("update", this.onEdgesUpdated);
        this._edges.off("remove", this.onEdgesRemoved);
      }
    }

    this._edges = edgesValue;

    if (this._edges) {
      if (this._edges) {
        this._edges.on("add", this.onEdgesUpdated);
        this._edges.on("update", this.onEdgesUpdated);
        this._edges.on("remove", this.onEdgesRemoved);
      }
    }
  }

  private nodeLayoutsSubject: Subject<NodeLayout>;
  public get nodeLayoutsStream(): Observable<NodeLayout> {
    return this.nodeLayoutsSubject.asObservable();
  }

  private onNodesUpdated(event: string, properties: any, sender: IdType) {
    if (this.network) {
      let nodeLayouts = this.nodes.get(properties.items as string[]).map<NodeLayout>(node => {
        let width, height: number;

        if (node.shape == "circularImage") {
          width = this.settingsService.settings.ui.circularImageSize;
          height = this.settingsService.settings.ui.circularImageSize;
        } else {
          let boundingBox = this.network.getBoundingBox(node.id);
          width = Math.abs(boundingBox.right - boundingBox.left);
          height = Math.abs(boundingBox.bottom - boundingBox.top);
        }

        return {
          id: node.id.toString(),
          positionX: node.x.valueOf(),
          positionY: node.y.valueOf(),
          width: width,
          height: height
        }
      });

      for (let nodeLayout of nodeLayouts) {
        this.nodeLayoutsSubject.next(nodeLayout);
      }      
    }
  }

  private onNodesRemoved(event: string, properties: any, sender: IdType) {
  }

  private onEdgesUpdated(event: string, properties: any, sender: IdType) {
  }

  private onEdgesRemoved(event: string, properties: any, sender: IdType) {
  }

  constructor(private settingsService: SettingsService) { }
}


