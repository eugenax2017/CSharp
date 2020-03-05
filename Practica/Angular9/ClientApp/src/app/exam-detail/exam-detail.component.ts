import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

import { ExamDetailService } from '../services/exam-detail.service';

@Component({
  selector: 'app-exam-detail',
  templateUrl: './exam-detail.component.html',
  styleUrls: []
})
export class ExamDetailComponent implements OnInit {
  examForms: FormArray = this.fb.array([]);
  notification = null;

  model: NgbDateStruct;
  placement = 'right';

  constructor(private fb: FormBuilder, private examService: ExamDetailService) { }

  ngOnInit(): void {
    this.examForms.clear();
    this.examService.getExams().subscribe(
      res => {
        if (res === []) {
          this.addExamForm();
        } else {
          (res as []).forEach((exam: any) => {
            this.examForms.push(this.fb.group({
              id: [exam.id],
              title: [exam.title],
              text: [exam.text],
              date: [exam.date],
              subjectId: [exam.subjectId]
            }));
          });
        }
      }
    );
  }

  addExamForm() {
    this.examForms.push(this.fb.group({
      id: [this.returnGuidEmpty()],
      title: [''],
      text: [''],
      date: [''],
      subjectId: ['']
    }));
  }

  recordSubmit(fg: FormGroup) {
    let message = 'update';
    if (fg.value.id === this.returnGuidEmpty()) {
      message = 'insert';
    }
    this.examService.postExam(fg.value).subscribe(
        (res: any) => {
           // fg.patchValue({ id: res.id });
           this.showNotification(message);
           this.ngOnInit();
         });
   // } //else {
      // this.studentService.putStudent(fg.value).subscribe(
         // (res: any) => {
         // this.showNotification('update');
         // });
   // }
  }

  returnGuidEmpty() {
    return '00000000-0000-0000-0000-000000000000';
  }

  onDelete(id, i) {
    if (id === this.returnGuidEmpty()) {
      this.examForms.removeAt(i);
    } else if (confirm('Are you sure to delete this record ?')) {
      this.examService.deleteExam(id).subscribe(
        (res) => {
          this.examForms.removeAt(i);
          this.showNotification('delete');
        });
     }
  }

  showNotification(category) {
    switch (category) {
      case 'insert':
        this.notification = { class: 'text-success', message: 'saved!' };
        break;
      case 'update':
        this.notification = { class: 'text-primary', message: 'updated!' };
        break;
      case 'delete':
        this.notification = { class: 'text-danger', message: 'deleted!' };
        break;

      default:
        break;
    }
    setTimeout(() => {
      this.notification = null;
    }, 3000);
  }

}
