import { HttpClient } from '@angular/common/http';
import { Component} from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent{

  constructor(private http: HttpClient) {}
  
  title = 'filmssaver.client';
}
