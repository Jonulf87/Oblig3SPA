import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TreeAnswerComponent } from './tree-answer.component';

describe('TreeAnswerComponent', () => {
  let component: TreeAnswerComponent;
  let fixture: ComponentFixture<TreeAnswerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TreeAnswerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TreeAnswerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
