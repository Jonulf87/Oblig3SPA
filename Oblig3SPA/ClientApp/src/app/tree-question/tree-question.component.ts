import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-tree-question',
  templateUrl: './tree-question.component.html',
  styleUrls: ['./tree-question.component.css']
})
export class TreeQuestionComponent  {
  @Input() categoryId: number;

  constructor() { }

}
