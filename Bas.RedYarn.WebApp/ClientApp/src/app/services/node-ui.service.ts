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
      let nodeLayout = this.nodeLayouts[key];
      let x: number;
      let y: number;

      switch (this.diagramInfoService.getItemType(nodeLayout.id)) {
        case DiagramItemType.PlotElement:
          const iconSize = 25;
          x = nodeLayout.positionX + (nodeLayout.width / 2) - iconSize * 2;
          y = nodeLayout.positionY - (nodeLayout.height / 2) - (iconSize / 1.1);
          this.diagramDrawingService.drawPuzzlePieceIcon(x, y);
          break;
        case DiagramItemType.Storyline:
          const iconWidth = 40;
          const iconHeight = 30;
          x = nodeLayout.positionX + (nodeLayout.width / 2) - iconWidth * 1.5;
          y = nodeLayout.positionY - (nodeLayout.height / 2) - (iconHeight / 1.7);
          this.diagramDrawingService.drawBookIcon(x,y);
          break;
        default:
          break;
      }      
    }
  }
}
