import { Directive, Input, ElementRef, Output, EventEmitter } from '@angular/core';
import { Network, IdType } from 'vis';

@Directive({
  selector: '[appVisNetwork]'
})
export class VisNetworkDirective {
  private network: Network 
  
  constructor(private element: ElementRef) { }

  @Input() set appVisNetwork(networkData) {
    let options = {   
      physics: {
          enabled: false          
        }
      };

    if (!this.network) {
      this.network = new Network(this.element.nativeElement, networkData, options);
      this.network.on("dragEnd", params => this.dragEnd.emit(params));
    }
  }

  @Output() dragEnd: EventEmitter<any> = new EventEmitter();

  focusOnNode(nodeId: IdType): void {
    if (this.network) {
      this.network.focus(nodeId, {
        locked: false,
        animation: { duration: 1000, easingFunction: "easeInOutQuad" },
        scale: this.network.getScale()
      });
    }
  }
}
