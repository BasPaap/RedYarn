import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-new-diagram-dialog',
  templateUrl: './new-diagram-dialog.component.html',
  styleUrls: ['./new-diagram-dialog.component.scss']
})
export class NewDiagramDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<NewDiagramDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: string) { }

  ngOnInit() {
  }

}
