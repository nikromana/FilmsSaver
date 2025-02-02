import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";

@Injectable({
  providedIn: 'root'
})

export class FilmsService {


  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient, private router: Router) { }

  searchFilms(films_search_word: string)
  {

  }

  getSavedFilms() {

  }

  deleteFilmFromSaved()
  {

  }
}
