import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { DiagramService } from '../diagram.service';
import { DialogComponent } from '../dialog/dialog.component';
import { Guid } from '../../Guid';

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
        xPosition: 0,
        yPosition: 0
      };

      this.diagramService.createStoryline(storylineViewModel)
        .subscribe(() => this.dialogRef.close());
    }
  }

  constructor(private dialogRef: MatDialogRef<NewStorylineDialogComponent>, private diagramService: DiagramService) {
    super();

    this.formGroup.addControl('name', new FormControl('', [Validators.required]));
    this.formGroup.addControl('description', new FormControl());
  }

  ngOnInit() {
  }

}
