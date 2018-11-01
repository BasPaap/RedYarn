import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule, MatButtonModule, MatFormFieldModule, MatCheckboxModule, MatInputModule, MatDialogModule, MatSidenavModule, MatListModule, ErrorStateMatcher, ShowOnDirtyErrorStateMatcher, MatChipsModule, MatIconModule, MatProgressSpinnerModule } from '@angular/material';
import { LoginDialogComponent } from './login-dialog/login-dialog.component';
import { MainToolbarComponent } from './main-toolbar/main-toolbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { StoryDiagramComponent } from './story-diagram/story-diagram.component';
import { AppRoutingModule } from './app-routing.module';
import { NewDiagramDialogComponent } from './new-diagram-dialog/new-diagram-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NewCharacterDialogComponent } from './new-character-dialog/new-character-dialog.component';
import { ChipsInputComponent } from './chips-input/chips-input.component';
import { NewStorylineDialogComponent } from './new-storyline-dialog/new-storyline-dialog.component';
import { VisNetworkDirective } from './vis-network.directive';
import { NewPlotElementDialogComponent } from './new-plot-element-dialog/new-plot-element-dialog.component';
import { DefaultDialogActionsComponent } from './default-dialog-actions/default-dialog-actions.component';

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
    DefaultDialogActionsComponent
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
    NewPlotElementDialogComponent
  ],
  providers: [{ provide: ErrorStateMatcher, useClass: ShowOnDirtyErrorStateMatcher }],
  bootstrap: [AppComponent]
})
export class AppModule { }
