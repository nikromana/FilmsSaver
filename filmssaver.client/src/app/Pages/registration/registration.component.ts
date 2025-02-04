import { Component, inject} from '@angular/core';
import { AuthenticationService } from '../../Services/AuthenticationService';

@Component({
  selector: 'app-registration',
  standalone: false,
  
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {

  authService = inject(AuthenticationService);

  formActionUrl: string = 'http://localhost:5062/Auth/registration';

  registration(registrationData: any) {
    console.log(registrationData.value);
    this.authService.registration(registrationData.value);
  }

}
