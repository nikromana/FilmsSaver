import { Component, inject } from '@angular/core';
import { AuthenticationService } from '../../Services/AuthenticationService';

@Component({
  selector: 'app-login',
  standalone: false,
  
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  authService = inject(AuthenticationService);
  formActionUrl: string = 'http://localhost:5062/Auth/login';

  goRegistration() {
    console.log("Go to registration");
  }
}
