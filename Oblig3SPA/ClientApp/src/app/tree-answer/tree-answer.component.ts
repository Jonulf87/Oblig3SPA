import { Component, OnInit, Input, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { faAngleUp, faAngleDown } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-tree-answer',
  templateUrl: './tree-answer.component.html',
  styleUrls: ['./tree-answer.component.css']
})
export class TreeAnswerComponent implements OnInit {
    @Input() questionId: number;
    public answers: Answer[];
    public faAngleUp = faAngleUp;
    public faAngleDown = faAngleDown;

    constructor(private _http: HttpClient, @Inject('BASE_URL') private _baseUrl: string) {
    }

    ngOnInit() {
        this._http.get<Answer[]>(this._baseUrl + 'api/questions/answer/' + this.questionId).subscribe(result => {
            this.answers = result;
        }, error => console.error(error));
    }

    public voteUp(answerId: number) {
        const headers = new HttpHeaders().set("Content-Type", "application/json");
        this._http.put(this._baseUrl + 'api/questions/voteup/' + answerId, null, {headers: headers}).subscribe(result => {
            for (let i = 0; i < this.answers.length; i++) {
                if (this.answers[i].id == answerId) {
                    this.answers[i].rating++;
                    break;
                }
            }
        }, error => console.error(error));
    }

    public voteDown(answerId: number) {
        const headers = new HttpHeaders().set("Content-Type", "application/json");
        this._http.put(this._baseUrl + 'api/questions/votedown/' + answerId, null, { headers: headers }).subscribe(result => {
            for (let i = 0; i < this.answers.length; i++) {
                if (this.answers[i].id == answerId) {
                    this.answers[i].rating--;
                    break;
                }
            }
        }, error => console.error(error));
    }
}

interface Answer {
    id: number;
    answerText: string;
    rating: number;
}
