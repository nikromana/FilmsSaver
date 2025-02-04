import { Component, inject } from '@angular/core';
import { AuthenticationService } from '../../Services/AuthenticationService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: false,
  
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  authService = inject(AuthenticationService);

  constructor(private router: Router) { }

  login(loginFormData: any) {
    console.log(loginFormData.value);
    this.authService.login(loginFormData.value);
  }

  goRegistration() {
    console.log("Go to registration");
    this.router.navigate(['/registration']);
  }
}
