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

  onEnter(): void {
    if (this.newDiagramForm.valid) {
      this.dialogRef.close(this.newDiagramForm.controls["name"].value);
    }
  }

  constructor(public dialogRef: MatDialogRef<NewDiagramDialogComponent>, private diagramService: DiagramService, private router: Router) {
    dialogRef.afterClosed().subscribe(diagramName => {
      if (diagramName) {
        this.diagramService.createDiagram(diagramName)
          .subscribe(newDiagram => {
            this.router.navigate(['diagrams', newDiagram.id]);
          });
      }
    });
  }

  ngOnInit() {
  }

}
