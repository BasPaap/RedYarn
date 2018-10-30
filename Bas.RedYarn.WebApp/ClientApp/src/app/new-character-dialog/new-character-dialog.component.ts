import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { DiagramService } from '../diagram.service';
import { Router } from '@angular/router';
import { ENTER, SEMICOLON } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material';


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

  readonly separatorKeyCodes: number[] = [ENTER, SEMICOLON];
  aliases: string[] = [];
  removable = true;

  constructor(public dialogRef: MatDialogRef<NewCharacterDialogComponent>, private diagramService: DiagramService, private router: Router) { }

  add(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;
    
    if ((value || '').trim()) {
      this.aliases.push(value.trim());
    }

    // Reset the input value
    if (input) {
      input.value = '';
    }
  }

  remove(alias: string): void {
    const index = this.aliases.indexOf(alias);

    if (index >= 0) {
      this.aliases.splice(index, 1);
    }
  }

  ngOnInit() {
    
  }

}
