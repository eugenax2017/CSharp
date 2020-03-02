import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { StudentPostService } from '../services/student-post.service';
import { Student } from '../models/student';

@Component({
  selector: 'app-student-posts',
  templateUrl: './student-posts.component.html',
  styleUrls: ['./student-posts.component.css']
})
export class StudentPostsComponent implements OnInit {
  Students$: Observable<Student[]>;

  constructor(private studentPostService: StudentPostService) { }

  ngOnInit(): void {
    this.loadStudents();
  }

  loadStudents(){
    this.studentPostService.getStudents();
  }

}
