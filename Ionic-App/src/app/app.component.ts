import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core'; 
@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  constructor(private translate: TranslateService) {

    this.initializeApp();
  }
  initializeApp() {
    // other stuff...
    this.translate.setDefaultLang('en'); 
  }

}