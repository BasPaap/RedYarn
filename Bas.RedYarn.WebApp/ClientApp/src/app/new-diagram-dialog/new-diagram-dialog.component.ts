import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { DiagramService } from '../diagram.service';
import { Router } from '@angular/router';
import { DialogComponent } from '../dialog/dialog.component';

@Component({
  selector: 'app-new-diagram-dialog',
  templateUrl: './new-diagram-dialog.component.html',
  styleUrls: ['./new-diagram-dialog.component.scss']
})
export class NewDiagramDialogComponent extends DialogComponent implements OnInit {

  onEnter(): void {
    this.createDiagram();
  }

  createDiagram(): void {
    if (this.formGroup.valid) {
      this.toggleIsSubmitting();
      
      this.diagramService.createDiagram(this.formGroup.controls['name'].value)
        .subscribe(newDiagram => {
          this.dialogRef.close();
          this.router.navigate(['diagram', newDiagram.id]);
        });
    }
  }

  constructor(public dialogRef: MatDialogRef<NewDiagramDialogComponent>, private diagramService: DiagramService, private router: Router) {
    super();
    
    this.formGroup.addControl("name", new FormControl('', [Validators.required]));    
  }

  ngOnInit() {
  }
}
