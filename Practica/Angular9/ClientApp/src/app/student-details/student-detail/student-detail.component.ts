import { StudentDetailService } from './../../services/student-detail.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-student-detail',
  templateUrl: './student-detail.component.html',
  styles: []
})
export class StudentDetailComponent implements OnInit {

  constructor(private service: StudentDetailService) { }

  ngOnInit(): void {
  }

}
