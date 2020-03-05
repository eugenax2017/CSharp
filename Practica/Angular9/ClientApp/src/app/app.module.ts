import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StudentDetailComponent } from './student-detail/student-detail.component';
import { StudentDetailService } from './services/student-detail.service';
import { HttpClientModule } from '@angular/common/http';
import { SubjectDetailComponent } from './subject-detail/subject-detail.component';
import { SubjectDetailService } from './services/subject-detail.service';
import { ExamDetailComponent } from './exam-detail/exam-detail.component';
import { ExamDetailService } from './services/exam-detail.service';
import { NavbarComponent } from './navbar/navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    StudentDetailComponent,
    SubjectDetailComponent,
    ExamDetailComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [
    StudentDetailService,
    SubjectDetailService,
    ExamDetailService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
