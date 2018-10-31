import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { DiagramService } from '../diagram.service';

@Component({
  selector: 'app-new-storyline-dialog',
  templateUrl: './new-storyline-dialog.component.html',
  styleUrls: ['./new-storyline-dialog.component.scss']
})
export class NewStorylineDialogComponent implements OnInit {

  newStorylineForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    description: new FormControl('')
  });

  isSubmitting: boolean = false;

  disableFormControls() {
    for (let key in this.newStorylineForm.controls) {
      if (this.newStorylineForm.controls[key].disabled) {
        this.newStorylineForm.controls[key].enable();
      }
      else {
        this.newStorylineForm.controls[key].disable();
      }
    }
  }

  createStoryline(): void {
    this.isSubmitting = true;
    this.disableFormControls();

    let storylineViewModel = {
      id: "00000000-0000-0000-0000-000000000000",
      name: this.newStorylineForm.controls['name'].value,
      description: this.newStorylineForm.controls['description'].value,
      xPosition: 0,
      yPosition: 0
    };

    this.diagramService.createStoryline(storylineViewModel)
      .subscribe(() => this.dialogRef.close());
  }

  constructor(public dialogRef: MatDialogRef<NewStorylineDialogComponent>, private diagramService: DiagramService) { }

  ngOnInit() {
  }

}
