import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { DiagramService } from '../diagram.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-diagram-dialog',
  templateUrl: './new-diagram-dialog.component.html',
  styleUrls: ['./new-diagram-dialog.component.scss']
})
export class NewDiagramDialogComponent implements OnInit {
  newDiagramForm = new FormGroup({
    name: new FormControl('', [Validators.required])
  });

  isSubmitting: boolean = false;

  onEnter(): void {
    this.createDiagram();
  }

  disableFormControls() {
    for (let key in this.newDiagramForm.controls) {
      if (this.newDiagramForm.controls[key].disabled) {
        this.newDiagramForm.controls[key].enable();
      }
      else {
        this.newDiagramForm.controls[key].disable();
      }
    }
  }

  createDiagram(): void {
    if (this.newDiagramForm.valid) {
      this.isSubmitting = true;
      this.disableFormControls();

      this.diagramService.createDiagram(this.newDiagramForm.controls['name'].value)
        .subscribe(newDiagram => {
          this.dialogRef.close();
          this.router.navigate(['diagrams', newDiagram.id]);
        });
    }
  }

  constructor(public dialogRef: MatDialogRef<NewDiagramDialogComponent>, private diagramService: DiagramService, private router: Router) {    
  }

  ngOnInit() {
  }
}
