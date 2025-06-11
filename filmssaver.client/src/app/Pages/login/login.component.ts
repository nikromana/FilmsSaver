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

  authService = inject(AuthenticationService);

  constructor(private router: Router, private translate: TranslateService) {
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
    this.translate.use(lang);
  }
}
