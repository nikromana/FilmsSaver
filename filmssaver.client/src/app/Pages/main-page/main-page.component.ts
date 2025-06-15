import { Component, inject, OnInit } from '@angular/core';
import { AuthenticationService } from '../../Services/AuthenticationService';
import { MatDialog } from '@angular/material/dialog';
import { LangSelectComponent } from '../lang-select/lang-select.component';
import { TranslateService } from '@ngx-translate/core';
import { AppConstants } from '../../Share/Constants';
import { SignalRService } from '../../Services/SignalRService';

@Component({
  selector: 'app-main-page',
  standalone: false,
  
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.css'
})
export class MainPageComponent {

  currentLang = AppConstants.DEFAULT_LANG; 
  authServiece = inject(AuthenticationService);
  movieCount = 0;

  constructor(private langDialog: MatDialog,
    private translate: TranslateService,
    private signalRService: SignalRService) {

    const savedLang = localStorage.getItem(AppConstants.DEFAULT_LANG_DESCR);

    if (savedLang) {
      this.switchLanguage(savedLang);
    } else {
      this.translate.use(this.currentLang);
    }

    translate.setDefaultLang(this.currentLang);
    translate.use(this.currentLang);

    this.signalRService.movieCount$.subscribe(count => {
      this.movieCount = count;
    });

    this.signalRService.getMovieCount();
}

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

  switchLanguage(lang: string) {
    this.currentLang = lang;
    this.translate.use(lang);
    localStorage.setItem(AppConstants.DEFAULT_LANG_DESCR, lang);
  }
}
