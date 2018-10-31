import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { NewCharacterDialogComponent } from '../new-character-dialog/new-character-dialog.component';
import { NewStorylineDialogComponent } from '../new-storyline-dialog/new-storyline-dialog.component';
import { NewPlotElementDialogComponent } from '../new-plot-element-dialog/new-plot-element-dialog.component';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  constructor(private dialog: MatDialog) { }

  ngOnInit() {
  }

  public onNewCharacterClick() {
    this.dialog.open(NewCharacterDialogComponent);
  }

  public onNewStorylineClick() {
    this.dialog.open(NewStorylineDialogComponent);
  }

  public onNewPlotElementClick() {
    this.dialog.open(NewPlotElementDialogComponent);
  }
}
