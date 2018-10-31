import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { DiagramService } from '../diagram.service';

@Component({
  selector: 'app-new-plot-element-dialog',
  templateUrl: './new-plot-element-dialog.component.html',
  styleUrls: ['./new-plot-element-dialog.component.scss']
})
export class NewPlotElementDialogComponent implements OnInit {

  newPlotElementForm = new FormGroup({
    name: new FormControl('',  [Validators.required]),
    description: new FormControl('')
  });

  isSubmitting: boolean = false;

  createPlotElement(): void {
    this.isSubmitting = true;

    let plotElementViewModel = {
      id: "00000000-0000-0000-0000-000000000000",
      name: this.newPlotElementForm.controls['name'].value,
      description: this.newPlotElementForm.controls['description'].value,
      xPosition: 0,
      yPosition: 0
    };

    this.diagramService.createPlotElement(plotElementViewModel)
      .subscribe(() => this.dialogRef.close());
  }

  constructor(public dialogRef: MatDialogRef<NewPlotElementDialogComponent>, private diagramService: DiagramService) { }

  ngOnInit() {
  }

}
