import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { Guid } from '../../../Guid';
import { DiagramDataService } from '../../services/diagram-data.service';
import { NetworkItemsConstructorService } from '../../services/network-items-constructor.service';
import { DialogComponent } from '../dialog/dialog.component';

@Component({
  selector: 'app-new-plot-element-dialog',
  templateUrl: './plot-element-dialog.component.html',
  styleUrls: ['./plot-element-dialog.component.scss']
})
export class PlotElementDialogComponent extends DialogComponent implements OnInit {

  public createPlotElement(): void {
    if (this.formGroup.valid) {
      this.toggleIsSubmitting();

      let plotElementViewModel = {
        id: Guid.empty,
        name: this.formGroup.controls['name'].value,
        description: this.formGroup.controls['description'].value,
        xPosition: this.networkGeneratorService.getStartingCoordinate(),
        yPosition: this.networkGeneratorService.getStartingCoordinate()
      };

      this.diagramDataService.createPlotElement(plotElementViewModel)
        .subscribe(() => this.dialogRef.close());
    }
  }

  constructor(private dialogRef: MatDialogRef<PlotElementDialogComponent>, private diagramDataService: DiagramDataService, private networkGeneratorService: NetworkItemsConstructorService) {
    super();

    this.formGroup.addControl('name', new FormControl('', [Validators.required]));
    this.formGroup.addControl('description', new FormControl());
  }

  ngOnInit() {
  }

}
