import { Component, inject } from '@angular/core';
import { FilmsService } from '../../Services/FilmsService';

@Component({
  selector: 'app-films-search',
  standalone: false,
  
  templateUrl: './films-search.component.html',
  styleUrl: './films-search.component.css'
})
export class FilmsSearchComponent {

  filmService = inject(FilmsService);
  films: any[] = [];
  film: any = '';

  searchFilms() {

    var film_search_example = document.getElementById("search_film_text") as HTMLInputElement;

    if (film_search_example) {
      console.log(film_search_example.value);
    } else {
      console.log(film_search_example);
      return;
    }

    var film = this.filmService.searchFilms(film_search_example.value).subscribe(
      (response: any) => {

        console.log("from searchFilms: " + response.films);

        if (response.errors) {
          alert(response.errors);
          return;
        }

        //this row if i want to reload whole list of fimls 
        //this.films = [];

        this.films = [...this.films, response.films];

      },
      (error: string) => {
        console.log(error);
      }
    );

    console.log('after film' + film);
  }


}
