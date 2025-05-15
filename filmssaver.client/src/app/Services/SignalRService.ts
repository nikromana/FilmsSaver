

import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: signalR.HubConnection;

  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5062/moviehub') 
      .build();

    this.hubConnection.start()
      .then(() => console.log('SignalR Connection Established'))
      .catch(err => console.error('SignalR Connection Error: ', err));
  }
  
  receiveMovieCount(): void {
    this.hubConnection.on('ReceiveMovieCount', (movieCount: number) => {
      console.log('Updated Movie Count: ', movieCount);
    });
  }

  // Метод для отправки события добавления фильма
  addMovie(): void {
    this.hubConnection.invoke('AddMovie')
      .catch(err => console.error('Error while adding movie: ', err));
  }
}
