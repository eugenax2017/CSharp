import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { StudentPostsComponent } from './student-posts/student-posts.component';


const routes: Routes = [
  {path: '', component: StudentPostsComponent, pathMatch: 'full'},
  {path: '**', redirectTo: '/'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

