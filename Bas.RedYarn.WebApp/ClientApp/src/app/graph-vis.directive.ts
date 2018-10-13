import { Directive, TemplateRef, ViewContainerRef, Input, Renderer2, ElementRef } from '@angular/core';
import { Network } from 'vis';

@Directive({
  selector: '[appGraphVis]'
})
export class GraphVisDirective {
  private network: Network 
  
  constructor(private el: ElementRef) { }

  @Input() set appGraphVis(graphData) {
    let options = {   
      physics: {
          enabled: false          
        }
      };

    if (!this.network) {
      this.network = new Network(this.el.nativeElement, graphData, options);
    }
  }
}
