import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionSubmitComponent } from './question-submit.component';

describe('QuestionSubmitComponent', () => {
  let component: QuestionSubmitComponent;
  let fixture: ComponentFixture<QuestionSubmitComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuestionSubmitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuestionSubmitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
