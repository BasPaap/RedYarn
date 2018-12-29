import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Guid } from '../../../Guid';
import { DiagramDataService } from '../../services/diagram-data.service';
import { NetworkItemsConstructorService } from '../../services/network-items-constructor.service';
import { DialogComponent } from '../dialog/dialog.component';

@Component({
  selector: 'app-new-character-dialog',
  templateUrl: './character-dialog.component.html',
  styleUrls: ['./character-dialog.component.scss']
})
export class CharacterDialogComponent extends DialogComponent implements OnInit {
  
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

      this.diagramDataService.createCharacter(characterViewModel)
        .subscribe(() => this.dialogRef.close());
    }
  }

  constructor(private dialogRef: MatDialogRef<CharacterDialogComponent>,
              private diagramDataService: DiagramDataService,
              private networkGeneratorService: NetworkItemsConstructorService,
              @Inject(MAT_DIALOG_DATA) data) {
    super();

    this.formGroup.addControl('name', new FormControl('', [Validators.required]));
    this.formGroup.addControl('description', new FormControl(''));


    if (data) {
      this.isInReadMode = true;
      this.formGroup.controls['name'].setValue(data.name);
      this.formGroup.controls['description'].setValue(data.description);
      this.aliases = data.aliases;
      this.authors = data.authors;
    }
  }

  ngOnInit() {
  }
}
