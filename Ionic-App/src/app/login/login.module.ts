import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { LoginPageRoutingModule } from './login-routing.module';

import { LoginPage } from './login.page';

import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { HttpClientModule, HttpClient } from '@angular/common/http';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule.forRoot(),
    LoginPageRoutingModule,
    HttpClientModule, 
    TranslateModule.forRoot({ 
      loader: { 
        provide: TranslateLoader,
        useFactory: (createTranslateLoader),
        deps: [HttpClient] 
      } 
    }) 
  ],
  
  declarations: [LoginPage]
})
export class LoginPageModule {}
export function createTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}