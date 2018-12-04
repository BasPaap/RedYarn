import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StoryDiagramComponent } from './components/story-diagram/story-diagram.component';

const routes: Routes = [
  { path: 'diagram', component: StoryDiagramComponent },
  { path: 'diagram/:id', component: StoryDiagramComponent }
];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)]
})
export class AppRoutingModule { }
