import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TreeCategoryComponent } from './tree-category.component';

describe('TreeCategoryComponent', () => {
  let component: TreeCategoryComponent;
  let fixture: ComponentFixture<TreeCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TreeCategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TreeCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
