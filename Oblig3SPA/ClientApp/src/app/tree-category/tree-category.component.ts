import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-tree-category',
    templateUrl: './tree-category.component.html',
    styleUrls: ['./tree-category.component.css']
})
export class TreeCategoryComponent {
    public categories: Category[];
    public selectedCategory: number;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<Category[]>(baseUrl + 'api/questions/categories').subscribe(result => {
            this.categories = result;

            if (this.categories.length > 0) {
                this.selectedCategory = this.categories[0].id;
            }
        }, error => console.error(error));

    }

    public toggleActive(categoryId: number): void {
        this.selectedCategory = categoryId;
    }
}

interface Category {
    id: number;
    name: string;
}
