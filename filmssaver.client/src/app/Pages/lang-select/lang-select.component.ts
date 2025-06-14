import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { AppConstants } from '../../Share/Constants';
import {  MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-lang-select',
  standalone: false,
  templateUrl: './lang-select.component.html',
  styleUrl: './lang-select.component.css'
})
export class LangSelectComponent {

  currentLang = AppConstants.DEFAULT_LANG; 

  constructor(private translate: TranslateService, public dialogRef: MatDialogRef<LangSelectComponent>) {
    const savedLang = localStorage.getItem(AppConstants.DEFAULT_LANG_DESCR);

    if (savedLang) {
      this.switchLanguage(savedLang);
    } else {
      this.translate.use(this.currentLang);
    }

    translate.setDefaultLang(this.currentLang);
    translate.use(this.currentLang); 
  }

  switchLanguage(lang: string) {
    this.currentLang = lang;
    this.translate.use(lang);
    localStorage.setItem(AppConstants.DEFAULT_LANG_DESCR, lang);
  }

  close(): void {
    this.dialogRef.close();
  }
}

function Inject(MAT_DIALOG_DATA: any): (target: LangSelectComponent, propertyKey: "data") => void {
    throw new Error('Function not implemented.');
}
