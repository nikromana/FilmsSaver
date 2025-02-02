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
    const searchData = { filmSearch: films_search_word };

    this.http.get<string>('http://localhost:5062/Film/search', { params: searchData })
      .subscribe(
        (response: any) => {

          console.log("from searchFilms: " + response.films);
          console.log("from searchFilms: " + response);

          return response;
        },
        (error: string) => {
          console.log(error);
        }
      );
  }

  getSavedFilms() {

  }

  deleteFilmFromSaved()
  {

  }
}
