import { Component, inject, OnInit } from '@angular/core';
import { AuthenticationService } from '../../Services/AuthenticationService';
import { MatDialog } from '@angular/material/dialog';
import { LangSelectComponent } from '../lang-select/lang-select.component';

@Component({
  selector: 'app-main-page',
  standalone: false,
  
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.css'
})
export class MainPageComponent {

  authServiece = inject(AuthenticationService);

  constructor(private langDialog: MatDialog) { }

  logout()
  {
    this.authServiece.logout();
  }

  selectLangWindow() {
    this.langDialog.open(LangSelectComponent, {
      width: '300px',
      minWidth : '100px'
    });
  }

}
