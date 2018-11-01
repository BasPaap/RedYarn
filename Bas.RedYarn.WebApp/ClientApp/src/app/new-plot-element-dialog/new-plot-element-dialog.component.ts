import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { DiagramService } from '../diagram.service';
import { DialogComponent } from '../dialog.component';

@Component({
  selector: 'app-new-plot-element-dialog',
  templateUrl: './new-plot-element-dialog.component.html',
  styleUrls: ['./new-plot-element-dialog.component.scss']
})
export class NewPlotElementDialogComponent extends DialogComponent implements OnInit {

  createPlotElement(): void {
    if (this.formGroup.valid) {
      this.toggleSubmitting();

      let plotElementViewModel = {
        id: "00000000-0000-0000-0000-000000000000",
        name: this.formGroup.controls['name'].value,
        description: this.formGroup.controls['description'].value,
        xPosition: 0,
        yPosition: 0
      };

      this.diagramService.createPlotElement(plotElementViewModel)
        .subscribe(() => this.dialogRef.close());
    }
  }

  constructor(public dialogRef: MatDialogRef<NewPlotElementDialogComponent>, private diagramService: DiagramService) {
    super();

    this.formGroup.addControl('name', new FormControl('', [Validators.required]));
    this.formGroup.addControl('description', new FormControl());
  }

  ngOnInit() {
  }

}
