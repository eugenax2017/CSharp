import { TestBed } from '@angular/core/testing';

import { StudentPostService } from './student-post.service';

describe('StudentPostService', () => {
  let service: StudentPostService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StudentPostService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
