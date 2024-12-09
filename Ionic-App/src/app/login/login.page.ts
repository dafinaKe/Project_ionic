import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { AuthService } from './auth.service';
import { AlertController } from '@ionic/angular';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {
  email: string = '';
  password: string = '';
  language: string;

  constructor(
    private translateService: TranslateService,
    private router: Router,
    private authService: AuthService,
    private alertCtrl: AlertController
  ) {
    this.language = this.translateService.currentLang || 'en'; // Default language
  }

  ngOnInit() {
    this.translateService.use(this.language); // Set the initial language
  }

  async login() {
    if (!this.email || !this.password) {
      await this.showAlert('Error', 'Please fill out all fields.');
      return;
    }

    this.authService.login(this.email, this.password).subscribe({
      next: (response: any) => {
        if (response.success) {
          localStorage.setItem('token', response.data[0]);
          this.router.navigate(['/tabs/tab3']);
        } else {
          this.showAlert('Error', response.message || 'Invalid email or password.');
        }
      },
      error: () => {
        this.showAlert('Error', 'Failed to connect to the server.');
      },
    });
  }

  languageChange() {
    this.language = this.language === 'en' ? 'sq' : 'en';
    this.translateService.use(this.language);
  }

  private async showAlert(header: string, message: string) {
    const alert = await this.alertCtrl.create({
      header,
      message,
      buttons: ['OK'],
    });
    await alert.present();
  }
}
