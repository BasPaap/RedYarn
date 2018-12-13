import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule, MatButtonModule, MatFormFieldModule, MatCheckboxModule, MatInputModule, MatDialogModule, MatSidenavModule, MatListModule, ErrorStateMatcher, ShowOnDirtyErrorStateMatcher, MatChipsModule, MatIconModule, MatProgressSpinnerModule } from '@angular/material';
import { LoginDialogComponent } from './components/login-dialog/login-dialog.component';
import { MainToolbarComponent } from './components/main-toolbar/main-toolbar.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { StoryDiagramComponent } from './components/story-diagram/story-diagram.component';
import { AppRoutingModule } from './app-routing.module';
import { NewDiagramDialogComponent } from './components/new-diagram-dialog/new-diagram-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NewCharacterDialogComponent } from './components/new-character-dialog/new-character-dialog.component';
import { ChipsInputComponent } from './components/chips-input/chips-input.component';
import { NewStorylineDialogComponent } from './components/new-storyline-dialog/new-storyline-dialog.component';
import { VisNetworkDirective } from './vis-network.directive';
import { NewPlotElementDialogComponent } from './components/new-plot-element-dialog/new-plot-element-dialog.component';
import { DefaultDialogActionsComponent } from './components/default-dialog-actions/default-dialog-actions.component';
import { DialogComponent } from './components/dialog/dialog.component';
import { NewRelationshipDialogComponent } from './components/new-relationship-dialog/new-relationship-dialog.component';
import { NewCharacterPlotElementDialogComponent } from './components/new-character-plotelement-dialog/new-character-plotelement-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginDialogComponent,
    MainToolbarComponent,
    SidebarComponent,
    StoryDiagramComponent,
    VisNetworkDirective,
    NewDiagramDialogComponent,
    NewCharacterDialogComponent,
    ChipsInputComponent,
    NewStorylineDialogComponent,
    NewPlotElementDialogComponent,
    DefaultDialogActionsComponent,
    DialogComponent,
    NewRelationshipDialogComponent,
    NewCharacterPlotElementDialogComponent
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
    ReactiveFormsModule,
    MatChipsModule,
    MatIconModule,
    MatProgressSpinnerModule    
  ],
  entryComponents: [
    LoginDialogComponent,
    NewDiagramDialogComponent,
    NewCharacterDialogComponent,
    NewStorylineDialogComponent,
    NewPlotElementDialogComponent,
    NewRelationshipDialogComponent,
    NewCharacterPlotElementDialogComponent
  ],
  providers: [{ provide: ErrorStateMatcher, useClass: ShowOnDirtyErrorStateMatcher }],
  bootstrap: [AppComponent]
})
export class AppModule { }
