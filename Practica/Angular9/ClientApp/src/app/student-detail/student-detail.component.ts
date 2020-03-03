import { StudentDetailService } from './../services/student-detail.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormArray, FormGroup  } from '@angular/forms';
import { HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-student-detail',
  templateUrl: './student-detail.component.html',
  styles: []
})

export class StudentDetailComponent implements OnInit {

  studentForms: FormArray = this.fb.array([]);
  studentsList = [];

  constructor(private fb: FormBuilder, private studentService: StudentDetailService) { }

  ngOnInit(): void {
    this.studentService.getStudents().subscribe(
      res => {
        if (res === []) {
          this.addStudentForm();
        } else {
          // generate formarray as per the data received from BankAccont table
          (res as []).forEach((student: any) => {
            this.studentForms.push(this.fb.group({
              id: [student.id],
              name: [student.name],
              email: [student.email],
              dni: [student.dni],
              chairNumber: [student.chairNumber]
            }));
          });
        }
      }
    );
  }

  addStudentForm() {
    this.studentForms.push(this.fb.group({
      // id: [0],
      name: [''],
      email: [''],
      dni: [''],
      chairNumber: [0],
    }));
  }

  recordSubmit(fg: FormGroup) {
    // if (fg.value.id === 0) {
      this.studentService.postStudent(fg.value).subscribe(
       // (res: any) => {
         // fg.patchValue({ id: res.id });
          //// this.showNotification('insert');
        // });
   // } else {
   //   this.studentService.putStudent(fg.value).subscribe(
        (res: any) => {
          // this.showNotification('update');
        });
   // }
  }

  onDelete(id, i) {
    if (id === 0) {
      this.studentForms.removeAt(i);
    } else if (confirm('Are you sure to delete this record ?')) {
      this.studentService.deleteStudent(id).subscribe(
        (res) => {
          this.studentForms.removeAt(i);
          // this.showNotification('delete');
        });
 }
  }

}
