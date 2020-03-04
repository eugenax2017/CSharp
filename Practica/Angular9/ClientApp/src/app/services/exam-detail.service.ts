import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ExamDetailService {

  constructor(private http: HttpClient) { }

  postExam(formData) {
    return this.http.post(environment.apiBaseURI + '/Exams', formData);
  }

  putExam(formData) {
    return this.http.put(environment.apiBaseURI + '/Exams/' + formData.id, formData);
  }

  deleteExam(id) {
    return this.http.delete(environment.apiBaseURI + '/Exams/' + id);
  }

  getExams() {
    return this.http.get(environment.apiBaseURI + '/Exams');
  }
}
