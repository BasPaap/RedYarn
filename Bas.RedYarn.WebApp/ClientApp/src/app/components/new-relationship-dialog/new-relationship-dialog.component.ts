import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Guid } from '../../../Guid';
import { DiagramDataService } from '../../services/diagram-data.service';
import { DialogComponent } from '../dialog/dialog.component';

@Component({
  selector: 'app-new-relationship-dialog',
  templateUrl: './new-relationship-dialog.component.html',
  styleUrls: ['./new-relationship-dialog.component.scss']
})
export class NewRelationshipDialogComponent extends DialogComponent implements OnInit {

  private fromNodeId: string;
  private toNodeId: string;

  public createRelationship(): void {
    if (this.formGroup.valid) {
      this.toggleIsSubmitting();

      let relationshipViewModel = {
        id: Guid.empty,
        fromNodeId: this.fromNodeId,
        toNodeId: this.toNodeId,
        isDirectional: true,
        name: this.formGroup.controls['name'].value
      };

      this.diagramDataService.createRelationship(relationshipViewModel)
        .subscribe(() => this.dialogRef.close());
    }
  }

  constructor(private dialogRef: MatDialogRef<NewRelationshipDialogComponent>, private diagramDataService: DiagramDataService, @Inject(MAT_DIALOG_DATA) data) {
    super();

    this.formGroup.addControl('name', new FormControl('', [Validators.required]));
    this.fromNodeId = data.fromNodeId;
    this.toNodeId = data.toNodeId;
  }

  ngOnInit() {
  }

}
