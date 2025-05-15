import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Pages/login/login.component';
import { RegistrationComponent } from './Pages/registration/registration.component';
import { MainPageComponent } from './Pages/main-page/main-page.component';
import { FilmsSavedComponent } from './Pages/films-saved/films-saved.component';
import { FilmsSearchComponent } from './Pages/films-search/films-search.component';
import { AuthGuard } from './Pages/auth.guard';
import { AboutComponent } from './Pages/about/about.component';

const routes: Routes = [
  { path: '', component: LoginComponent},
  { path: 'login', component: LoginComponent},
  { path: 'registration', component: RegistrationComponent },
  {
    path: 'main-page', component: MainPageComponent, children: [
    { path: 'about', component: AboutComponent, outlet: 'main_page_outlet' },
    { path: 'films-saved', component: FilmsSavedComponent, outlet: 'main_page_outlet' },
    { path: 'films-search', component: FilmsSearchComponent, outlet: 'main_page_outlet' }], canActivate: [AuthGuard]
  } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
