import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { DiagramService } from '../diagram.service';
import { DialogComponent } from '../dialog/dialog.component';
import { Guid } from '../../Guid';
import { VisNetworkGeneratorService } from '../vis-network-generator.service';

@Component({
  selector: 'app-new-character-dialog',
  templateUrl: './new-character-dialog.component.html',
  styleUrls: ['./new-character-dialog.component.scss']
})
export class NewCharacterDialogComponent extends DialogComponent implements OnInit {
  
  public aliases: string[] = [];
  public authors: string[] = [];

  public createCharacter(): void {
    if (this.formGroup.valid) {
      this.toggleIsSubmitting();

      let characterViewModel = {
        id: Guid.empty,
        name: this.formGroup.controls['name'].value,
        description: this.formGroup.controls['description'].value,
        aliases: this.aliases.map(alias => { return { id: Guid.empty, name: alias } }),
        xPosition: this.networkGeneratorService.getStartingCoordinate(),
        yPosition: this.networkGeneratorService.getStartingCoordinate()
      };

      this.diagramService.createCharacter(characterViewModel)
        .subscribe(() => this.dialogRef.close());
    }
  }

  constructor(private dialogRef: MatDialogRef<NewCharacterDialogComponent>, private diagramService: DiagramService, private networkGeneratorService: VisNetworkGeneratorService) {
    super();
    this.formGroup.addControl('name', new FormControl('', [Validators.required]));
    this.formGroup.addControl('description', new FormControl(''));
  }

  ngOnInit() {
  }
}
