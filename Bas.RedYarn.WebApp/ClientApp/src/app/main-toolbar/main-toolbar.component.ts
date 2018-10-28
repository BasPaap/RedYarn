import { Component, Inject, OnInit } from '@angular/core';
import { LoginDialogComponent } from '../login-dialog/login-dialog.component';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DiagramService } from '../diagram.service';
import { NewDiagramDialogComponent } from '../new-diagram-dialog/new-diagram-dialog.component';

@Component({
  selector: 'app-main-toolbar',
  templateUrl: './main-toolbar.component.html',
  styleUrls: ['./main-toolbar.component.scss']
})
export class MainToolbarComponent implements OnInit {

  constructor(public dialog: MatDialog, private diagramService: DiagramService) { }

  ngOnInit() {
  }

  public openLoginDialog() {
    const dialogRef = this.dialog.open(LoginDialogComponent, { data: "" });
  }

  public createNewDiagram() {
    const dialogRef = this.dialog.open(NewDiagramDialogComponent, { data: "" });
    dialogRef.afterClosed().subscribe(diagramName => {
      if (diagramName) {
        this.diagramService.createDiagram(diagramName);
      }
    });
  }

}
