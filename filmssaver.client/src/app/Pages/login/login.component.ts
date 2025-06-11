import { Component, inject } from '@angular/core';
import { AuthenticationService } from '../../Services/AuthenticationService';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-login',
  standalone: false,
  
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  currentLang = 'en'; 

  authService = inject(AuthenticationService);

  constructor(private router: Router, private translate: TranslateService) {
    const savedLang = localStorage.getItem('lang');

    if (savedLang) {
      this.switchLanguage(savedLang);
    } else {
      this.translate.use(this.currentLang);
    }

    translate.setDefaultLang('en');
    translate.use('en'); 
  }

  login(loginFormData: any) {
    console.log(loginFormData.value);
    this.authService.login(loginFormData.value);
  }

  goRegistration() {
    console.log("Go to registration");
    this.router.navigate(['/registration']);
  }

  switchLanguage(lang: string) {
    this.currentLang = lang;
    this.translate.use(lang);
    localStorage.setItem('lang', lang);
  }
}
