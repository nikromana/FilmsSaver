import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: signalR.HubConnection;

  public movieCount$ = new Subject<number>();
  public movieChanged$: Subject<void> = new Subject<void>();

  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5062/moviehub') 
      .build();

    this.hubConnection.start()
      .then(() => console.log('SignalR Connection Established'))
      .catch(err => console.error('SignalR Connection Error: ', err));

    this.hubConnection.on('ReceiveMovieCount', (movieCount: number) => {
      console.log('Updated Movie Count: ', movieCount);
      this.movieChanged$.next();
    });
  }

  getMovieCount() {
    this.hubConnection.invoke('GetMovieCount', (movieCount: number) => {
      console.log('Updated Movie Count: ', movieCount);
      this.movieCount$.next(movieCount);
    });
  }

  receiveMovieCount(): void {
    this.hubConnection.on('ReceiveMovieCount', (movieCount: number) => {
      console.log('Updated Movie Count: ', movieCount);
      this.movieCount$.next(movieCount);
    });
  }

  // Метод для отправки события добавления фильма
  addMovie(): void {
    this.hubConnection.invoke('AddMovie')
      .catch(err => console.error('Error while adding movie: ', err));
  }

  // Метод для отправки события добавления фильма
  deleteMovie(): void {
    this.hubConnection.invoke('DeleteMovie')
      .catch(err => console.error('Error while adding movie: ', err));
  }
}
