import { Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Login } from "../Models/Login"


@Injectable({
  providedIn: 'root'
})

export class AuthenticationService {

  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(private http: HttpClient, private router: Router) { }

  login(login: any) {
    const loginData = { Login: login.login, Password: login.password }

    this.http.get<string>('http://localhost:5062/Auth/login', { params: loginData, responseType: 'text' as 'json' })
      .subscribe((response: string) => {

        this.setTokenAndGoChats(response);

        return response;
      });
  }

  registration(registration: any) {
    console.log(registration);
    this.http.get<string>('http://localhost:5062/Auth/registration', { params: registration, responseType: 'text' as 'json' })
      .subscribe((response: string) => {
        
        this.setTokenAndGoChats(response);

        return response;
      });
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  setTokenAndGoChats(response: any) {
    if (response && response.Token) {
      localStorage.setItem('token', response.Token);
      this.router.navigate(['/chats']);
    }
  }

}
