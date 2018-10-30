import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { DiagramService } from '../diagram.service';
import { Router } from '@angular/router';

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

  constructor(public dialogRef: MatDialogRef<NewCharacterDialogComponent>, private diagramService: DiagramService, private router: Router) { }

  ngOnInit() {
    
  }

}
