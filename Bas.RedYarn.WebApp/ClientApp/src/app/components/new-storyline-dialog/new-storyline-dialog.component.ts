import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { Guid } from '../../../Guid';
import { DiagramDataService } from '../../services/diagram-data.service';
import { NetworkItemsConstructorService } from '../../services/network-items-constructor.service';
import { DialogComponent } from '../dialog/dialog.component';

@Component({
  selector: 'app-new-storyline-dialog',
  templateUrl: './new-storyline-dialog.component.html',
  styleUrls: ['./new-storyline-dialog.component.scss']
})
export class NewStorylineDialogComponent extends DialogComponent implements OnInit {

  public createStoryline(): void {
    if (this.formGroup.valid) {
      this.toggleIsSubmitting();

      let storylineViewModel = {
        id: Guid.empty,
        name: this.formGroup.controls['name'].value,
        description: this.formGroup.controls['description'].value,
        xPosition: this.networkGeneratorService.getStartingCoordinate(),
        yPosition: this.networkGeneratorService.getStartingCoordinate()
      };

      this.diagramDataService.createStoryline(storylineViewModel)
        .subscribe(() => this.dialogRef.close());
    }
  }

  constructor(private dialogRef: MatDialogRef<NewStorylineDialogComponent>, private diagramDataService: DiagramDataService, private networkGeneratorService: NetworkItemsConstructorService) {
    super();

    this.formGroup.addControl('name', new FormControl('', [Validators.required]));
    this.formGroup.addControl('description', new FormControl());


    this.isInReadMode = true;
  }

  ngOnInit() {
  }

}
