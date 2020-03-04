import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StudentDetailComponent } from './student-detail/student-detail.component';
import { StudentDetailService } from './services/student-detail.service';
import { HttpClientModule } from '@angular/common/http';
import { SubjectDetailComponent } from './subject-detail/subject-detail.component';
import { SubjectDetailService } from './services/subject-detail.service';
import { ExamDetailComponent } from './exam-detail/exam-detail.component';
import { ExamDetailService } from './services/exam-detail.service';

@NgModule({
  declarations: [
    AppComponent,
    StudentDetailComponent,
    SubjectDetailComponent,
    ExamDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    StudentDetailService,
    SubjectDetailService,
    ExamDetailService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
