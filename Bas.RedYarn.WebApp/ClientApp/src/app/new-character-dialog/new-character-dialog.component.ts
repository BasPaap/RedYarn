import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { DiagramService } from '../diagram.service';

@Component({
  selector: 'app-new-character-dialog',
  templateUrl: './new-character-dialog.component.html',
  styleUrls: ['./new-character-dialog.component.scss']
})
export class NewCharacterDialogComponent implements OnInit {

  newCharacterForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    description: new FormControl('')
  });

  aliases: string[] = [];
  authors: string[] = [];
  isSubmitting: boolean = false;

  disableFormControls() {
    for (let key in this.newCharacterForm.controls) {
      if (this.newCharacterForm.controls[key].disabled) {
        this.newCharacterForm.controls[key].enable();
      }
      else {
        this.newCharacterForm.controls[key].disable();
      }
    }
  }

  createCharacter(): void {
    this.isSubmitting = true;
    this.disableFormControls();

    let characterViewModel = {
      id: "00000000-0000-0000-0000-000000000000",
      name: this.newCharacterForm.controls['name'].value,
      description: this.newCharacterForm.controls['description'].value,
      aliases: this.aliases,
      xPosition: 0,
      yPosition: 0
    };

    this.diagramService.createCharacter(characterViewModel)
      .subscribe(() => this.dialogRef.close());
  }

  constructor(public dialogRef: MatDialogRef<NewCharacterDialogComponent>, private diagramService: DiagramService) {
  }

  ngOnInit() {
  }
}
