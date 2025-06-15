import { Component, inject, Input, OnInit } from '@angular/core';
import { FilmsService } from '../../Services/FilmsService';
import { SignalRService } from '../../Services/SignalRService';

@Component({
  selector: 'app-film-card',
  standalone: false,
  
  templateUrl: './film-card.component.html',
  styleUrl: './film-card.component.css'
})
export class FilmCardComponent implements OnInit {

  ngOnInit(): void {
    this.signalRService.receiveMovieCount();
  }

  constructor(private signalRService: SignalRService) { }

  @Input() film: any;
  @Input() addCard: any;

  filmService = inject(FilmsService);

  addOrRemoveFilmToFavorites(filmName: string) {

    if (this.addCard) {
      this.filmService.addFilmToFavorites(filmName);
      this.signalRService.addMovie();
    } else {
      this.filmService.deleteFilmFromSaved(filmName);
      this.signalRService.deleteMovie();
    }
  }


}
