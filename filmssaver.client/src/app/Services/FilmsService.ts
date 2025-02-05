import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs/internal/Observable";

@Injectable({
  providedIn: 'root'
})

export class FilmsService {

  constructor(private http: HttpClient, private router: Router) { }

  searchFilms(films_search_word: string) : Observable<any>
  {
    const searchData = { filmSearch: films_search_word };
    const headers = new HttpHeaders({ 'Authorization': `Bearer ${localStorage.getItem('token')}`, 'Content-Type': 'application/json' });

    return this.http.get<string>('https://localhost:5062/Film/search', { headers , params: searchData });
  }

  addFilmToFavorites(filmName : string) {

    const headers = new HttpHeaders({ 'Authorization': `Bearer ${localStorage.getItem('token')}`, 'Content-Type': 'application/json' });
    const saveData = { FilmName: filmName };

    return this.http.post<string>('https://localhost:5062/Film/save', saveData ,{ headers }).subscribe(
      (response: any) => {

        console.log("from searchFilms: " + response.films);

        if (response.errors) {
          alert(response.errors);
          return;
        }

      },
      (error: string) => {
        console.log(error);
      }
    );
  }

  getSavedFilms() {
    const headers = new HttpHeaders({ 'Authorization': `Bearer ${localStorage.getItem('token')}`, 'Content-Type': 'application/json' });
    const saveData = {};
    return this.http.post<any>('https://localhost:5062/Film/getSavedFilms', saveData, { headers });
  }

  deleteFilmFromSaved()
  {

  }
}
