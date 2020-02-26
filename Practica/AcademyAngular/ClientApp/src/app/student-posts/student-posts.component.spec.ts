import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentPostsComponent } from './student-posts.component';

describe('StudentPostsComponent', () => {
  let component: StudentPostsComponent;
  let fixture: ComponentFixture<StudentPostsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentPostsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentPostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
