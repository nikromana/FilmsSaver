import { Component, inject, OnInit } from '@angular/core';
import { FilmsService } from '../../Services/FilmsService';
import { SignalRService } from '../../Services/SignalRService';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-films-saved',
  standalone: false,
  
  templateUrl: './films-saved.component.html',
  styleUrl: './films-saved.component.css'
})
export class FilmsSavedComponent implements OnInit {

  filmService = inject(FilmsService);
  films: any[] = [];
  private signalRSubscription?: Subscription;

  constructor(private signalRService: SignalRService) { }

  ngOnInit(): void {
    this.loadFilms(); 

    this.signalRSubscription = this.signalRService.movieChanged$.subscribe(() => {
      this.loadFilms(); 
    });
  }

  loadFilms(): void {
    this.filmService.getSavedFilms().subscribe(
      (response: any) => {
        if (response.errors) {
          alert(response.errors);
          return;
        }

        this.films = [...response.userFilms];
      },
      (error: string) => {
        console.log(error);
      }
    );
  }

  ngOnDestroy(): void {
    this.signalRSubscription?.unsubscribe();
  }
}
