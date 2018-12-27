import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule, MatProgressBarModule, MatButtonModule, MatFormFieldModule, MatCheckboxModule, MatInputModule, MatDialogModule, MatSidenavModule, MatListModule, ErrorStateMatcher, ShowOnDirtyErrorStateMatcher, MatChipsModule, MatIconModule, MatProgressSpinnerModule } from '@angular/material';
import { MatRadioModule } from '@angular/material/radio';
import { LoginDialogComponent } from './components/login-dialog/login-dialog.component';
import { MainToolbarComponent } from './components/main-toolbar/main-toolbar.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { StoryDiagramComponent } from './components/story-diagram/story-diagram.component';
import { AppRoutingModule } from './app-routing.module';
import { NewDiagramDialogComponent } from './components/new-diagram-dialog/new-diagram-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CharacterDialogComponent } from './components/character-dialog/character-dialog.component';
import { ChipsInputComponent } from './components/chips-input/chips-input.component';
import { StorylineDialogComponent } from './components/storyline-dialog/storyline-dialog.component';
import { VisNetworkDirective } from './vis-network.directive';
import { PlotElementDialogComponent } from './components/plot-element-dialog/plot-element-dialog.component';
import { DialogComponent } from './components/dialog/dialog.component';
import { NewRelationshipDialogComponent } from './components/new-relationship-dialog/new-relationship-dialog.component';
import { NewCharacterPlotElementDialogComponent } from './components/new-character-plotelement-dialog/new-character-plotelement-dialog.component';
import { DrawableDirective } from './drawable.directive';
import { ConfirmationDialogComponent } from './components/confirmation-dialog/confirmation-dialog.component';
import { MyDiagramsComponent } from './components/my-diagrams/my-diagrams.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginDialogComponent,
    MainToolbarComponent,
    SidebarComponent,
    StoryDiagramComponent,
    VisNetworkDirective,
    NewDiagramDialogComponent,
    CharacterDialogComponent,
    ChipsInputComponent,
    StorylineDialogComponent,
    PlotElementDialogComponent,
    DialogComponent,
    NewRelationshipDialogComponent,
    NewCharacterPlotElementDialogComponent,
    DrawableDirective,
    ConfirmationDialogComponent,
    MyDiagramsComponent
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
    MatRadioModule,
    MatListModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatChipsModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatProgressBarModule
  ],
  entryComponents: [
    LoginDialogComponent,
    NewDiagramDialogComponent,
    CharacterDialogComponent,
    StorylineDialogComponent,
    PlotElementDialogComponent,
    NewRelationshipDialogComponent,
    NewCharacterPlotElementDialogComponent,
    ConfirmationDialogComponent
  ],
  providers: [{ provide: ErrorStateMatcher, useClass: ShowOnDirtyErrorStateMatcher }],
  bootstrap: [AppComponent]
})
export class AppModule { }
