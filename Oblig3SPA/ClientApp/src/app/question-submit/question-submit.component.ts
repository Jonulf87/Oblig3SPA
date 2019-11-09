import { Component, OnInit, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-question-submit',
  templateUrl: './question-submit.component.html',
  styleUrls: ['./question-submit.component.css']
})
export class QuestionSubmitComponent implements OnInit {
    @Input() questionText: string;
    public question: Question;

    constructor(private _http: HttpClient, @Inject('BASE_URL') private _baseUrl: string) { }

    ngOnInit() {
        
    }

    public postQuestion() {
        this._http.post<Question>(this._baseUrl + 'api/questions', { questionText: this.questionText }).subscribe(result => {
            this.question = result;
        }, error => console.error(error));
    }

}

interface Question {
    id: number;
    questionText: string;
}
