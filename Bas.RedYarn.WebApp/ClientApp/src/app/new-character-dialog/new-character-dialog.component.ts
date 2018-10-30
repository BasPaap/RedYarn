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

  constructor(public dialogRef: MatDialogRef<NewCharacterDialogComponent>, private diagramService: DiagramService) {
    dialogRef.afterClosed().subscribe(isSubmitted => {
      if (isSubmitted) {

        let characterViewModel = {
          id: "00000000-0000-0000-0000-000000000000",
          name: this.newCharacterForm.controls['name'].value,
          description: this.newCharacterForm.controls['description'].value,
          aliases: this.aliases
        };
        
        this.diagramService.createCharacter(characterViewModel)
          .subscribe(newCharacter => {
            // Somehow broadcast the new character so StoryDiagram will pick it up and add it.
          });
      }
    });
  }

  ngOnInit() {
    
  }

}
