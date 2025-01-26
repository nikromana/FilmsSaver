import { Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Login } from "../Models/Login"


@Injectable{
  providedIn: 'root'
}

export class AuthenticationService {

  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(private http: HttpClient, private router: Router) { }

  login(login: Login) {
    const loginData = { EmailLogin: login.Login, password: login.Password }

    this.http.get<any>('https://localhost:7044/Authentication/login', { params: loginData })
      .subscribe((response: any) => {

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
