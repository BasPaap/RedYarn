import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule, MatButtonModule, MatFormFieldModule, MatDialogModule, MatSidenavModule, MatListModule } from '@angular/material';
import { LoginDialogComponent } from './login-dialog/login-dialog.component';
import { MainToolbarComponent } from './main-toolbar/main-toolbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { StoryDiagramComponent } from './story-diagram/story-diagram.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginDialogComponent,
    MainToolbarComponent,
    SidebarComponent,
    StoryDiagramComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatFormFieldModule,
    MatDialogModule,
    MatSidenavModule,
    MatListModule
  ],
  entryComponents : [ LoginDialogComponent ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
