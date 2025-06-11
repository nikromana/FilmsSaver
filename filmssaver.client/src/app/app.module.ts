import { HttpClientModule, HttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Pages/login/login.component';
import { RegistrationComponent } from './Pages/registration/registration.component';
import { MainPageComponent } from './Pages/main-page/main-page.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FilmsSearchComponent } from './Pages/films-search/films-search.component';
import { FilmsSavedComponent } from './Pages/films-saved/films-saved.component';
import { FilmCardComponent } from './Pages/film-card/film-card.component';
import { FilmPageComponent } from './Pages/film-page/film-page.component';
import { AboutComponent } from './Pages/about/about.component';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { LangSelectComponent } from './Pages/lang-select/lang-select.component';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './i18n/', '.json');
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    MainPageComponent,
    FilmsSearchComponent,
    FilmsSavedComponent,
    FilmCardComponent,
    FilmPageComponent,
    AboutComponent,
    LangSelectComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, FormsModule, NgbModule,
    HttpClientModule,
    TranslateModule.forRoot({
      defaultLanguage: 'en',
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
