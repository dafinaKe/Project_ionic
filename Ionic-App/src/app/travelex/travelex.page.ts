import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-travelex',
  templateUrl: './travelex.page.html',
  styleUrls: ['./travelex.page.scss'],
})
export class TravelexPage implements OnInit {
  language: string = 'en'; // Gjuha fillestare është anglisht

  constructor(private translateService: TranslateService) { }

  ngOnInit() {
    // Përdorim anglisht fillimisht
    this.translateService.setDefaultLang('en');
    this.translateService.use('en');
  }

  // Funksioni për ndërrimin e gjuhës
  changeLanguage() {
    if (this.language === 'en') {
      this.translateService.use('sq');
      this.language = 'sq';
    } else {
      this.translateService.use('en');
      this.language = 'en';
    }
  }
}
