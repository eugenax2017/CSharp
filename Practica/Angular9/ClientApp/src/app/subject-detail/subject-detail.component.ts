import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { SubjectDetailService } from '../services/subject-detail.service';

@Component({
  selector: 'app-subject-detail',
  templateUrl: './subject-detail.component.html',
  styles: []
})
export class SubjectDetailComponent implements OnInit {
  subjectForms: FormArray = this.fb.array([]);
  notification = null;

  constructor(private fb: FormBuilder, private subjectService: SubjectDetailService) { }

  ngOnInit(): void {
    this.subjectForms.clear();
    this.subjectService.getSubjects().subscribe(
      res => {
        if (res === []) {
          this.addSubjectForm();
        } else {
          (res as []).forEach((subject: any) => {
            this.subjectForms.push(this.fb.group({
              id: [subject.id],
              name: [subject.name],
              teacher: [subject.teacher]
            }));
          });
        }
      }
    );
  }

  addSubjectForm() {
    this.subjectForms.push(this.fb.group({
      id: [this.returnGuidEmpty()],
      name: [''],
      teacher: ['']
    }));
  }

  recordSubmit(fg: FormGroup) {
    let message = 'update';
    if (fg.value.id === this.returnGuidEmpty()) {
      message = 'insert';
    }
    this.subjectService.postSubject(fg.value).subscribe(
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
      this.subjectForms.removeAt(i);
    } else if (confirm('Are you sure to delete this record ?')) {
      this.subjectService.deleteSubject(id).subscribe(
        (res) => {
          this.subjectForms.removeAt(i);
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
