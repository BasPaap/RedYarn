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
          enabled: true,
          barnesHut: {
            springConstant: 0,
            damping: 1
          },
          minVelocity: 0.75
        }
      };

    if (!this.network) {
      this.network = new Network(this.el.nativeElement, graphData, options);
    }
  }
}
