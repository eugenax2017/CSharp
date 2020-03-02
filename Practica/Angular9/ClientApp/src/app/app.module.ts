import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgForm } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StudentDetailComponent } from './student-details/student-detail/student-detail.component';
import { StudentDetailListComponent } from './student-details/student-detail-list/student-detail-list.component';
import { StudentDetailsComponent } from './student-details/student-details.component';
import { StudentDetailService } from './services/student-detail.service';

@NgModule({
  declarations: [
    AppComponent,
    StudentDetailComponent,
    StudentDetailListComponent,
    StudentDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgForm
  ],
  providers: [StudentDetailService],
  bootstrap: [AppComponent]
})
export class AppModule { }
