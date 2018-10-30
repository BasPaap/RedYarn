import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule, MatButtonModule, MatFormFieldModule, MatCheckboxModule, MatInputModule, MatDialogModule, MatSidenavModule, MatListModule, ErrorStateMatcher, ShowOnDirtyErrorStateMatcher } from '@angular/material';
import { LoginDialogComponent } from './login-dialog/login-dialog.component';
import { MainToolbarComponent } from './main-toolbar/main-toolbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { StoryDiagramComponent } from './story-diagram/story-diagram.component';
import { GraphVisDirective } from './graph-vis.directive';
import { AppRoutingModule } from './app-routing.module';
import { NewDiagramDialogComponent } from './new-diagram-dialog/new-diagram-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NewCharacterDialogComponent } from './new-character-dialog/new-character-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginDialogComponent,
    MainToolbarComponent,
    SidebarComponent,
    StoryDiagramComponent,
    GraphVisDirective,
    NewDiagramDialogComponent,
    NewCharacterDialogComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatFormFieldModule,
    MatCheckboxModule,
    MatInputModule,
    MatDialogModule,
    MatSidenavModule,
    MatListModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  entryComponents: [LoginDialogComponent, NewDiagramDialogComponent, NewCharacterDialogComponent],
  providers: [{ provide: ErrorStateMatcher, useClass: ShowOnDirtyErrorStateMatcher }],
  bootstrap: [AppComponent]
})
export class AppModule { }
