import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { CharacterDialogComponent } from '../character-dialog/character-dialog.component';
import { PlotElementDialogComponent } from '../plot-element-dialog/plot-element-dialog.component';
import { StorylineDialogComponent } from '../storyline-dialog/storyline-dialog.component';

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
    this.dialog.open(CharacterDialogComponent);
  }

  public onNewStorylineClick() {
    this.dialog.open(StorylineDialogComponent);
  }

  public onNewPlotElementClick() {
    this.dialog.open(PlotElementDialogComponent);
  }
}
