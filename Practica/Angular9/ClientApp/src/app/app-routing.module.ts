import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { StudentDetailComponent } from './student-detail/student-detail.component';
import { SubjectDetailComponent } from './subject-detail/subject-detail.component';
import { ExamDetailComponent } from './exam-detail/exam-detail.component';

const routes: Routes = [
  { path: '', component: StudentDetailComponent },
  { path: 'students', component: StudentDetailComponent },
  { path: 'subjects', component: SubjectDetailComponent },
  { path: 'exams', component: ExamDetailComponent },
  { path: '**', component: StudentDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
