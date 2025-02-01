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

    this.http.get<string>('http://localhost:5062/Auth/login', { params: loginData})
      .subscribe((response: any) => {
        console.log("from subscribe" + response)
        this.setToken(response);

        return response;
      },
        (error: string) => {
          console.log(error);
        });
  }

  registration(registration: any) {
    console.log(registration);
    this.http.get<string>('http://localhost:5062/Auth/registration', { params: registration })
      .subscribe((response : any) => {
        
        this.setToken(response);

        if (localStorage.getItem('token')) {
          this.router.navigate(['/main-page']);
        }

        return response;
      },
        (error: any) => {
          console.log(error);
        });
  }

  setToken(response: any) {
    if (response && response.Token) {
      localStorage.setItem('token', response.Token);
    }
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
