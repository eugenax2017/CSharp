import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StudentPostService } from './services/student-post.service';
import { StudentPostsComponent } from './student-posts/student-posts.component';

@NgModule({
  declarations: [
    AppComponent,
    StudentPostsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [
    StudentPostService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
