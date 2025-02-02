import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs/internal/Observable";

@Injectable({
  providedIn: 'root'
})

export class FilmsService {


  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient, private router: Router) { }

  searchFilms(films_search_word: string) : Observable<any>
  {
    const searchData = { filmSearch: films_search_word };

    return this.http.get<string>('http://localhost:5062/Film/search', { params: searchData });
  }

  getSavedFilms() {

  }

  deleteFilmFromSaved()
  {

  }
}
