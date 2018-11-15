import { Component, OnInit } from '@angular/core';
import { DialogComponent } from '../dialog/dialog.component';
import { Validators, FormControl } from '@angular/forms';
import { DiagramService } from '../diagram.service';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-new-relationship-dialog',
  templateUrl: './new-relationship-dialog.component.html',
  styleUrls: ['./new-relationship-dialog.component.scss']
})
export class NewRelationshipDialogComponent extends DialogComponent implements OnInit {
  
  public createRelationship(): void {
    if (this.formGroup.valid) {
      this.toggleIsSubmitting();

      //let storylineViewModel = {
      //  id: "00000000-0000-0000-0000-000000000000",
      //  name: this.formGroup.controls['name'].value,
      //  description: this.formGroup.controls['description'].value,
      //  xPosition: 0,
      //  yPosition: 0
      //};

      //this.diagramService.createStoryline(storylineViewModel)
      //  .subscribe(() => this.dialogRef.close());
    }
  }

  constructor(private dialogRef: MatDialogRef<NewRelationshipDialogComponent>, private diagramService: DiagramService) {
    super();

    this.formGroup.addControl('name', new FormControl('', [Validators.required]));
  }

  ngOnInit() {
  }

}
