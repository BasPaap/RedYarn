import { Component, Inject, OnInit, ChangeDetectorRef, Input, Output, EventEmitter } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatRadioGroup, MatRadioChange } from '@angular/material';
import { DiagramDataService } from '../../services/diagram-data.service';
import { DialogComponent } from '../dialog/dialog.component';
import { DiagramInfoService } from 'src/app/services/diagram-info.service';
import { PlotElement, Character } from 'src/app/diagram-types';

@Component({
  selector: 'app-new-character-plotelement-dialog',
  templateUrl: './new-character-plotelement-dialog.component.html',
  styleUrls: ['./new-character-plotelement-dialog.component.scss']
})
export class NewCharacterPlotElementDialogComponent extends DialogComponent implements OnInit {

  public character: Character;
  public plotElement: PlotElement;
  
  @Input() public characterHasPlotElement: boolean;

  public onCharacterHasPlotElementChanged(change: MatRadioChange) {
    this.characterHasPlotElement = change.value;
  }

  public createCharacterPlotElementConnection(): void {
    if (this.formGroup.valid) {
      this.toggleIsSubmitting();

      let characterPlotElementViewModel = {
        fromNodeId: this.character.id,
        toNodeId: this.plotElement.id,
        characterOwnsPlotElement: this.characterHasPlotElement
      };

      this.diagramDataService.createCharacterPlotElementConnection(characterPlotElementViewModel)
        .subscribe(() => this.dialogRef.close());
    }
  }

  constructor(private dialogRef: MatDialogRef<NewCharacterPlotElementDialogComponent>, private diagramDataService: DiagramDataService, private diagramInfoService: DiagramInfoService, @Inject(MAT_DIALOG_DATA) data) {
    super();

    this.characterHasPlotElement = true;
    this.character = this.diagramInfoService.getCharacter(data.fromNodeId);
    this.plotElement = this.diagramInfoService.getPlotElement(data.toNodeId);    
  }

  ngOnInit() {
  }

}
