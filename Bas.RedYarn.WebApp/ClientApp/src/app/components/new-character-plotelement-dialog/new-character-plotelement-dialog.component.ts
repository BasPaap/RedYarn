import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Guid } from '../../../Guid';
import { DiagramDataService } from '../../services/diagram-data.service';
import { DialogComponent } from '../dialog/dialog.component';

@Component({
  selector: 'app-new-character-plotelement-dialog',
  templateUrl: './new-character-plotelement-dialog.component.html',
  styleUrls: ['./new-character-plotelement-dialog.component.scss']
})
export class NewCharacterPlotElementDialogComponent extends DialogComponent implements OnInit {

  private fromNodeId: string;
  private toNodeId: string;

  public createCharacterPlotElementConnection(): void {
    if (this.formGroup.valid) {
      this.toggleIsSubmitting();

      //let relationshipViewModel = {
      //  id: Guid.empty,
      //  fromNodeId: this.fromNodeId,
      //  toNodeId: this.toNodeId,
      //  isDirectional: true,
      //  name: this.formGroup.controls['name'].value
      //};

      //this.diagramDataService.createRelationship(relationshipViewModel)
      //  .subscribe(() => this.dialogRef.close());
    }
  }

  constructor(private dialogRef: MatDialogRef<NewCharacterPlotElementDialogComponent>, private diagramDataService: DiagramDataService, @Inject(MAT_DIALOG_DATA) data) {
    super();

    this.formGroup.addControl('characterOwnsPlotElement', new FormControl(''));
    this.fromNodeId = data.fromNodeId;
    this.toNodeId = data.toNodeId;
  }

  ngOnInit() {
  }

}
