import { Component, OnInit } from '@angular/core';
import { LoginDialogComponent } from '../login-dialog/login-dialog.component';
import { MatDialog } from '@angular/material';
import { NewDiagramDialogComponent } from '../new-diagram-dialog/new-diagram-dialog.component';

@Component({
  selector: 'app-main-toolbar',
  templateUrl: './main-toolbar.component.html',
  styleUrls: ['./main-toolbar.component.scss']
})
export class MainToolbarComponent implements OnInit {

  constructor(private dialog: MatDialog) { }

  ngOnInit() {
  }

  public onLoginClick() {
    this.dialog.open(LoginDialogComponent, { data: "" });
  }

  public onNewDiagramClick() {
    this.dialog.open(NewDiagramDialogComponent);    
  }  
}
