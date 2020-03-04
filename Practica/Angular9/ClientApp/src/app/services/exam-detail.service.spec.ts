import { TestBed } from '@angular/core/testing';

import { ExamDetailService } from './exam-detail.service';

describe('ExamDetailService', () => {
  let service: ExamDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExamDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
