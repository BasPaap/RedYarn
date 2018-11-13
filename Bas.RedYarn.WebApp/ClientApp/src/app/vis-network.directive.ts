import { Directive, Input, ElementRef, Output, EventEmitter, OnDestroy } from '@angular/core';
import { Network, IdType } from 'vis-redyarn';
import { DiagramDrawingService } from './diagram-drawing.service';
import { NetworkItemsService } from './network-items.service';

@Directive({
  selector: '[appVisNetwork]'
})
export class VisNetworkDirective implements OnDestroy {
    
  private network: Network 

  constructor(private element: ElementRef, private diagramDrawingService: DiagramDrawingService, private networkItemsService: NetworkItemsService) { }

  @Input() public set appVisNetwork(networkData) {
    let options = {   
      physics: {
          enabled: false          
        }
      };

    if (!this.network) {
      this.network = new Network(this.element.nativeElement, networkData, options);
      this.network.on("dragEnd", params => this.dragEnd.emit(params));
      this.network.on("beforeDrawing", context => this.diagramDrawingService.onDrawBackgroundUI(context));
      this.network.on("afterDrawing", context => this.diagramDrawingService.onDrawForegroundUI(context));

      this.networkItemsService.network = this.network;
    }
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

  ngOnDestroy(): void {
    this.networkItemsService.network = null;
  }
}
