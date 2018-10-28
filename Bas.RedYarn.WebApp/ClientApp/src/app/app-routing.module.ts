import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StoryDiagramComponent } from './story-diagram/story-diagram.component';

const routes: Routes = [
  { path: 'diagrams', component: StoryDiagramComponent },
  { path: 'diagrams/:id', component: StoryDiagramComponent }
];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)]
})
export class AppRoutingModule { }
