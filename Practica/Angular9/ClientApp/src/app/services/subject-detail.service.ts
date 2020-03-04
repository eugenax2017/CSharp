import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SubjectDetailService {

  constructor(private http: HttpClient) { }

  postSubject(formData) {
    return this.http.post(environment.apiBaseURI + '/Subjects', formData);
  }

  putSubject(formData) {
    return this.http.put(environment.apiBaseURI + '/Subjects/' + formData.id, formData);
  }

  deleteSubject(id) {
    return this.http.delete(environment.apiBaseURI + '/Subjects/' + id);
  }

  getSubjects() {
    return this.http.get(environment.apiBaseURI + '/Subjects');
  }

}
