import { Injectable } from '@angular/core';
import { DiagramDrawingService } from './diagram-drawing.service';
import { NodeLayoutInfoService, NodeLayoutInfo } from './node-layout-info.service';
import { DiagramInfoService } from './diagram-info.service';
import { DiagramItemType } from '../diagram-types';

@Injectable({
  providedIn: 'root'
})
export class NodeUiService {

  private nodeLayouts: { [id: string]: NodeLayoutInfo } = {};

  constructor(private nodeLayoutInfoService: NodeLayoutInfoService, private diagramDrawingService: DiagramDrawingService, private diagramInfoService: DiagramInfoService) {
    this.nodeLayoutInfoService.nodeLayoutsStream.subscribe(nodeLayout => this.nodeLayouts[nodeLayout.id] = nodeLayout);
  }

  public onRedraw(): void {
    for (let key in this.nodeLayouts) {
      switch (this.diagramInfoService.getItemType(this.nodeLayouts[key].id)) {
        case DiagramItemType.PlotElement:
          this.diagramDrawingService.drawPuzzlePieceIcon(this.nodeLayouts[key].positionX, this.nodeLayouts[key].positionY);
          break;
        case DiagramItemType.Storyline:
          this.diagramDrawingService.drawBookIcon(this.nodeLayouts[key].positionX, this.nodeLayouts[key].positionY);
          break;
        default:
          break;
      }      
    }
  }
}
