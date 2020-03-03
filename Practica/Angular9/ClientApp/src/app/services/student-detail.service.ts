import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';



@Injectable({
  providedIn: 'root'
})
export class StudentDetailService {

  constructor(private http: HttpClient) { }

  postStudent(formData) {
    return this.http.post(environment.apiBaseURI + '/Students', formData);
  }

  putStudent(formData) {
    return this.http.put(environment.apiBaseURI + '/Students/' + formData.id, formData);
  }

  deleteStudent(id) {
    return this.http.delete(environment.apiBaseURI + '/Students/' + id);
  }

  getStudents() {
    return this.http.get(environment.apiBaseURI + '/Students');
  }
}
