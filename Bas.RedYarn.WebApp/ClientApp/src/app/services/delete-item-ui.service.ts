import { Injectable } from '@angular/core';
import { MatDialogConfig, MatDialog } from '@angular/material';
import { DiagramItemType } from '../diagram-types';
import { ConfirmationDialogComponent } from '../components/confirmation-dialog/confirmation-dialog.component';
import { DiagramInfoService } from './diagram-info.service';
import { DiagramDataService } from './diagram-data.service';

@Injectable({
  providedIn: 'root'
})
export class DeleteItemUiService {

  constructor(private dialog: MatDialog, private diagramInfoService: DiagramInfoService, private diagramDataService: DiagramDataService) { }

  private getDiagramItemTypeName(itemType: DiagramItemType): string {
    switch (itemType) {
      case DiagramItemType.Character:
        return "character";
      case DiagramItemType.Storyline:
        return "storyline";
      case DiagramItemType.PlotElement:
        return "plot element";
      case DiagramItemType.Relationship:
        return "relationship";
      case DiagramItemType.CharacterPlotElementConnection:
      case DiagramItemType.StorylineCharacterConnection:
      case DiagramItemType.StorylinePlotElementConnection:
        return "connection";
      default:
        return "";
    }
  }

  public deleteNode(node: any): void {
    let dialogConfig = new MatDialogConfig();
    let itemType = this.diagramInfoService.getItemType(node.id);

    dialogConfig.data = {
      title: `Delete ${this.getDiagramItemTypeName(itemType)}`,
      message: itemType == DiagramItemType.Character ? `Are you sure you want to delete ${node.label}?` :
        `Are you sure you want to delete this ${this.getDiagramItemTypeName(itemType)}?`,
      action: dialogRef => {
        switch (itemType) {
          case DiagramItemType.Character:
            this.diagramDataService.deleteCharacter(node.character).subscribe(_ => dialogRef.close());
            break;
          case DiagramItemType.Storyline:
            this.diagramDataService.deleteStoryline(node.storyline).subscribe(_ => dialogRef.close());
            break;
          case DiagramItemType.PlotElement:
            this.diagramDataService.deletePlotElement(node.plotElement).subscribe(_ => dialogRef.close());
            break;
          default:
            dialogRef.close();
            break;
        }
      }
    };

    this.dialog.open(ConfirmationDialogComponent, dialogConfig);
  }

  public deleteEdge(edge: any): void {
    let dialogConfig = new MatDialogConfig();
    let itemType = this.diagramInfoService.getItemType(edge.id);

    dialogConfig.data = {
      title: `Delete ${this.getDiagramItemTypeName(itemType)}`,
      message: `Are you sure you want to delete this ${this.getDiagramItemTypeName(itemType)}?`,
      action: dialogRef => {
        switch (itemType) {
          case DiagramItemType.Relationship:
            this.diagramDataService.deleteRelationship(edge.relationship).subscribe(_ => dialogRef.close());
            break;
          case DiagramItemType.CharacterPlotElementConnection:
            this.diagramDataService.deleteCharacterPlotElementConnection(edge.characterPlotElementConnection).subscribe(_ => dialogRef.close());
            break;
          case DiagramItemType.StorylineCharacterConnection:
            this.diagramDataService.deleteStorylineCharacterConnection(edge.storylineCharacterConnection).subscribe(_ => dialogRef.close());
            break;
          case DiagramItemType.StorylinePlotElementConnection:
            this.diagramDataService.deleteStorylinePlotElementConnection(edge.storylinePlotElementConnection).subscribe(_ => dialogRef.close());
          default:
            dialogRef.close();
            break;
        }
      }
    };

    this.dialog.open(ConfirmationDialogComponent, dialogConfig);
  }
}
