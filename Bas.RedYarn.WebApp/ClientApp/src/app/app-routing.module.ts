import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StoryDiagramComponent } from './components/story-diagram/story-diagram.component';
import { MyDiagramsComponent } from './components/my-diagrams/my-diagrams.component';

const routes: Routes = [
  { path: 'diagram', component: MyDiagramsComponent },
  { path: 'diagram/:id', component: StoryDiagramComponent }
];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)]
})
export class AppRoutingModule { }
