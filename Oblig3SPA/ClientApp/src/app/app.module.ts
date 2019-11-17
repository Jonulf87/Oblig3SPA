import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { TreeCategoryComponent } from './tree-category/tree-category.component';
import { TreeQuestionComponent } from './tree-question/tree-question.component';
import { TreeAnswerComponent } from './tree-answer/tree-answer.component';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { QuestionSubmitComponent } from './question-submit/question-submit.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        TreeCategoryComponent,
        TreeQuestionComponent,
        TreeAnswerComponent,
        QuestionSubmitComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FontAwesomeModule,
        FormsModule        
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
