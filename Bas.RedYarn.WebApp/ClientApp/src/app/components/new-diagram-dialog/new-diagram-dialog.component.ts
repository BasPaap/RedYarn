import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { Router } from '@angular/router';
import { DiagramDataService } from '../../services/diagram-data.service';
import { DialogComponent } from '../dialog/dialog.component';

@Component({
  selector: 'app-new-diagram-dialog',
  templateUrl: './new-diagram-dialog.component.html',
  styleUrls: ['./new-diagram-dialog.component.scss']
})
export class NewDiagramDialogComponent extends DialogComponent implements OnInit {

  public onEnter(): void {
    this.createDiagram();
  }

  public createDiagram(): void {
    if (this.formGroup.valid) {
      this.toggleIsSubmitting();
      
      this.diagramDataService.createDiagram(this.formGroup.controls['name'].value)
        .subscribe(newDiagram => {
          this.dialogRef.close();
          this.router.navigate(['diagram', newDiagram.id]);
        });
    }
  }

  constructor(private dialogRef: MatDialogRef<NewDiagramDialogComponent>, private diagramDataService: DiagramDataService, private router: Router) {
    super();
    
    this.formGroup.addControl("name", new FormControl('', [Validators.required]));    
  }

  ngOnInit() {
  }
}
