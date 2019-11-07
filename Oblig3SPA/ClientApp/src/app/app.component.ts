import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
    name = "";
    toggleButton = true;


    resetName() {
        this.name = "";
    }

    toggleButtonReset() {
        if (this.name === "") {
            this.toggleButton = true;
        }
        else {
            this.toggleButton = false;
        }
        return this.toggleButton;
    }
}
