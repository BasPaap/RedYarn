import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormControl, Validators, FormGroup } from '@angular/forms';

/** Error when invalid control is dirty, touched, or submitted. */
//export class MyErrorStateMatcher implements ErrorStateMatcher {
//  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
//    const isSubmitted = form && form.submitted;
//    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
//  }
//}

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
  
  constructor(public dialogRef: MatDialogRef<NewDiagramDialogComponent>) { }

  ngOnInit() {
  }

}
