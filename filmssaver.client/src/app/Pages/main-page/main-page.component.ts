import { Component, inject, OnInit } from '@angular/core';
import { AuthenticationService } from '../../Services/AuthenticationService';
import { SignalRService } from '../../Services/SignalRService';

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
