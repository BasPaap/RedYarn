import { Component, OnInit, Inject } from '@angular/core';
import { DialogComponent } from '../dialog/dialog.component';
import { Validators, FormControl } from '@angular/forms';
import { DiagramService } from '../diagram.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

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
        id: "00000000-0000-0000-0000-000000000000",
        fromNodeId: this.fromNodeId,
        toNodeId: this.toNodeId,
        isDirectional: true,
        name: this.formGroup.controls['name'].value
      };

      this.diagramService.createRelationship(relationshipViewModel)
        .subscribe(() => this.dialogRef.close());
    }
  }

  constructor(private dialogRef: MatDialogRef<NewRelationshipDialogComponent>, private diagramService: DiagramService, @Inject(MAT_DIALOG_DATA) data) {
    super();

    this.formGroup.addControl('name', new FormControl('', [Validators.required]));
    this.fromNodeId = data.fromNodeId;
    this.toNodeId = data.toNodeId;
  }

  ngOnInit() {
  }

}
