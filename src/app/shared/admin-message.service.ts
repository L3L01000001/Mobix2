import { EventEmitter, Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder, HttpTransportType } from '@microsoft/signalr';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AdminMessageService {
  private hubConnection: HubConnection;
  zaprimljenaPoruka = new EventEmitter<string>();
  connectionEstablished = new Subject<void>();

  constructor() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl('/contactHub', {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets
        }) 
      .build();

      this.hubConnection.start()
      .then(() => {
        console.log('SignalR connection established.');
        this.connectionEstablished.next();
      })
      .catch((err) => console.error(err));

    this.hubConnection.on('ReceiveMessage', (message: string) => {
      this.zaprimljenaPoruka.next(message);
    });
  }

  sendMessage(message: string) {
    this.hubConnection.invoke('SendMessage', message);
  }

}