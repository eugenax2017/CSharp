import { Student } from './../models/student.model';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StudentDetailService {
  formData: Student;

  constructor() { }
}
