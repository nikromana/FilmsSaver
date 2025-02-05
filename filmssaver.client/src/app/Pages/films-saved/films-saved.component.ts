import { Component, inject, OnInit } from '@angular/core';
import { FilmsService } from '../../Services/FilmsService';

@Component({
  selector: 'app-films-saved',
  standalone: false,
  
  templateUrl: './films-saved.component.html',
  styleUrl: './films-saved.component.css'
})
export class FilmsSavedComponent implements OnInit {


  filmService = inject(FilmsService);
  films: any[] = [];

  ngOnInit(): void {
    this.filmService.getSavedFilms().subscribe(
      (response: any) => {

        console.log("from searchFilms: " + response.films);

        if (response.errors) {
          alert(response.errors);
          return;
        }

        this.films = [...this.films, ...response.userFilms];

      },
      (error: string) => {
        console.log(error);
      }
    );
  }


}
