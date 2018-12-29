import { Directive, ElementRef, EventEmitter, Input, Output } from '@angular/core';
import { IdType, Network, Options } from 'vis-redyarn';
import { DiagramDrawingService } from './services/diagram-drawing.service';
import { NodeUiService } from './services/node-ui.service';
import { SettingsService } from './services/settings.service';

@Directive({
  selector: '[appVisNetwork]'
})
export class VisNetworkDirective {

  private options: Options;

  private network: Network;

  constructor(private element: ElementRef,
    private diagramDrawingService: DiagramDrawingService,
    private settingsService: SettingsService,
    private nodeUiService: NodeUiService) { }

  @Input() public set appVisNetwork(networkData) {

    if (!this.network) {
      this.options = JSON.parse(JSON.stringify(this.settingsService.settings.ui.networkOptions)); // Make a deep copy of the network options so they can change without affecting anything.

      this.network = new Network(this.element.nativeElement, networkData, this.options);
      this.network.on("initRedraw", _ => this.nodeUiService.onRedraw());
      this.network.on("beforeDrawing", context => this.diagramDrawingService.onDrawBackgroundUI(context));
      this.network.on("afterDrawing", context => this.diagramDrawingService.onDrawForegroundUI(context));
      this.network.on("dragStart", params => {
        this._isDragging = true;
        this.dragStart.emit(params);
      });
      this.network.on("dragEnd", params => {
        this._isDragging = false;
        this.dragEnd.emit(params);
      });
      this.network.on("dragging", params => this.dragging.emit(params));
      this.network.on("doubleClick", params => {
        if (params.nodes.length > 0 || params.edges.length > 0) {
          this.doubleClick.emit(params);
        }
      });

      this.element.nativeElement.childNodes[0].style.outline = "none"; // Visjs appears to overwrite any style you set on the div in the container, so we'll need to manually set it after creation.
    }
  }

  private _isDragging = false;
  public get isDragging(): boolean {
    return this.isViewDraggingEnabled ? this._isDragging : false;
  }

  public get isViewDraggingEnabled(): boolean {
    return this.options.interaction.dragView;
  }

  public set isViewDraggingEnabled(value: boolean) {
    this.options.interaction.dragView = value;
    this.network.setOptions(this.options);
  }

  @Output() public doubleClick: EventEmitter<any> = new EventEmitter();
  @Output() public dragStart: EventEmitter<any> = new EventEmitter();
  @Output() public dragEnd: EventEmitter<any> = new EventEmitter();
  @Output() public dragging: EventEmitter<any> = new EventEmitter();

  public focusOnNode(nodeId: IdType): void {
    if (this.network) {
      this.network.focus(nodeId, {
        locked: false,
        animation: { duration: 1000, easingFunction: "easeInOutQuad" },
        scale: this.network.getScale()
      });
    }
  }

  public getCanvasPosition(domPosition: vis.Position): vis.Position {
    return this.network.DOMtoCanvas(domPosition);
  }

  public getNodePosition(nodeId: string): vis.Position {
    return this.network.getPositions(nodeId);
  }

  public getNodePositions(): { [nodeId: string]: vis.Position } {
    return this.network.getPositions();
  }

  public getBoundingBox(node: vis.Node): vis.BoundingBox {
    return this.network.getBoundingBox(node.id);
  }

  public getCanvasCoordinates(x: number, y: number): [number, number] {

    let offsetTop = this.element.nativeElement.getBoundingClientRect().top;
    let offsetLeft = this.element.nativeElement.getBoundingClientRect().left;

    let position = this.network.DOMtoCanvas({ x: x - offsetLeft, y: y - offsetTop });

    return [position.x, position.y];
  }

  public getSelectedEdgeIds(): IdType[] {
    return this.network.getSelectedEdges();
  }

  public getSelectedNodeIds(): IdType[] {
    return this.network.getSelectedNodes();
  }

  public redraw() {
    this.network.redraw();
  }
}
