import { Component } from '@angular/core';
import { MatDialog } from '@angular/material';
import { LoginDialogComponent } from './login-dialog/login-dialog.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'RedYarn';

  constructor(private dialog: MatDialog) { }

  openLoginDialog() {
    const loginDialog = this.dialog.open(LoginDialogComponent);    
  }
}
