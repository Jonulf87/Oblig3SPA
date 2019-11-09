import { Component, Input, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-tree-question',
    templateUrl: './tree-question.component.html',
    styleUrls: ['./tree-question.component.css']
})
export class TreeQuestionComponent implements OnInit {
    @Input() categoryId: number;
    public questions: Question[];
    public selectedQuestion: number;

    constructor(private _http: HttpClient, @Inject('BASE_URL') private _baseUrl: string) {
    }

    ngOnInit() {
        this._http.get<Question[]>(this._baseUrl + 'api/questions/' + this.categoryId).subscribe(result => {
            this.questions = result;
        }, error => console.error(error));
    }

    public toggleActive(questionId: number): void {
        if (this.selectedQuestion === questionId) {
            this.selectedQuestion = null;
        }
        else {
            this.selectedQuestion = questionId;
        }
    }
}

interface Question {
    id: number;
    questionText: string;
}

