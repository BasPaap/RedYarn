import { Directive, Input, ElementRef, Output, EventEmitter } from '@angular/core';
import { Network, IdType, Options } from 'vis-redyarn';
import { DiagramDrawingService } from './services/diagram-drawing.service';
import { NetworkItemsService } from './services/network-items.service';

@Directive({
  selector: '[appVisNetwork]'
})
export class VisNetworkDirective {

  private network: Network
  private options: Options  = {
    physics: {
      enabled: false
    },
    interaction: {
      dragView: true,
      hover: true
    }
  };


  constructor(private element: ElementRef, private diagramDrawingService: DiagramDrawingService, private networkItemsService: NetworkItemsService) { }

  @Input() public set appVisNetwork(networkData) {

    if (!this.network) {
      this.network = new Network(this.element.nativeElement, networkData, this.options);
      this.network.on("beforeDrawing", context => this.diagramDrawingService.onDrawBackgroundUI(context));
      this.network.on("afterDrawing", context => this.diagramDrawingService.onDrawForegroundUI(context));
      this.network.on("dragStart", _ => this._isDragging = true);
      this.network.on("dragEnd", params => {
        this._isDragging = false;
        this.dragEnd.emit(params);
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

  @Output() public dragEnd: EventEmitter<any> = new EventEmitter();

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

  public redraw() {
    this.network.redraw();
  }
}
