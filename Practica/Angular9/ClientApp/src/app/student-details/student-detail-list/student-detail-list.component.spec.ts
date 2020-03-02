import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentDetailListComponent } from './student-detail-list.component';

describe('StudentDetailListComponent', () => {
  let component: StudentDetailListComponent;
  let fixture: ComponentFixture<StudentDetailListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentDetailListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentDetailListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
