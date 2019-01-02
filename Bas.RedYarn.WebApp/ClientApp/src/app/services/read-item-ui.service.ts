import { Injectable } from '@angular/core';
import { DiagramDataService } from './diagram-data.service';
import { DiagramInfoService } from './diagram-info.service';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { DiagramItemType } from '../diagram-types';
import { CharacterDialogComponent } from '../components/character-dialog/character-dialog.component';
import { StorylineDialogComponent } from '../components/storyline-dialog/storyline-dialog.component';
import { PlotElementDialogComponent } from '../components/plot-element-dialog/plot-element-dialog.component';

@Injectable({
  providedIn: 'root'
})
export class ReadItemUiService {

  constructor(private dialog: MatDialog, private diagramInfoService: DiagramInfoService) { }
  
  public readNode(node: any): void {
    let dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = false;
    let itemType = this.diagramInfoService.getItemType(node.id);

    switch (itemType) {
      case DiagramItemType.Character:
        dialogConfig.data = node.character;
        this.dialog.open(CharacterDialogComponent, dialogConfig);
        break;
      case DiagramItemType.Storyline:
        dialogConfig.data = node.storyline;
        this.dialog.open(StorylineDialogComponent, dialogConfig);
        break;
      case DiagramItemType.PlotElement:
        dialogConfig.data = node.plotElement;
        this.dialog.open(PlotElementDialogComponent, dialogConfig);
        break;
      default:        
        break;
    }
  }
}
