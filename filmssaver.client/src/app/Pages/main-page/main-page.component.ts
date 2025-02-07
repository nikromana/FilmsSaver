import { Component, inject } from '@angular/core';
import { AuthenticationService } from '../../Services/AuthenticationService';

@Component({
  selector: 'app-main-page',
  standalone: false,
  
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.css'
})
export class MainPageComponent {

  authServiece = inject(AuthenticationService);

  logout()
  {
    this.authServiece.logout();
  }

}
