import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DialogComponent } from '../dialog/dialog.component';

@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.scss']
})
export class ConfirmationDialogComponent extends DialogComponent implements OnInit {

  public title: string;
  public message: string;

  constructor(private dialogRef: MatDialogRef<ConfirmationDialogComponent>, @Inject(MAT_DIALOG_DATA) private data: any) {
    super();

    this.title = data.title;
    this.message = data.message;
  }

  public onOK() {
    this.toggleIsSubmitting();
    this.data.action(this.dialogRef);
  }

  ngOnInit() {
  }

}
