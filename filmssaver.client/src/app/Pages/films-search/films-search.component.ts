import { Component } from '@angular/core';

@Component({
  selector: 'app-films-search',
  standalone: false,
  
  templateUrl: './films-search.component.html',
  styleUrl: './films-search.component.css'
})
export class FilmsSearchComponent {


  searchFilms() {

    var film_search_example = document.getElementById("search_film_text") as HTMLInputElement;

    if (film_search_example) {
      var inputValue = film_search_example.value;
      console.log(film_search_example);
    } else {
      console.log(film_search_example);
    }


  }
}
