import { Component, inject, Input } from '@angular/core';
import { FilmsService } from '../../Services/FilmsService';

@Component({
  selector: 'app-film-card',
  standalone: false,
  
  templateUrl: './film-card.component.html',
  styleUrl: './film-card.component.css'
})
export class FilmCardComponent {

  @Input() film: any;
  filmService = inject(FilmsService);

  addFilmToFavorites(filmName: string) {
    this.filmService.addFilmToFavorites(filmName);
  }
}
