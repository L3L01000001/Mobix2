import { EventEmitter, Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder, HttpTransportType, HubConnectionState } from '@microsoft/signalr';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AdminMessageService {
  private hubConnection: HubConnection;
  private poruke: string[] = [];
  connectionEstablished = new Subject<void>();
  private receivedMessageSource = new Subject<string>();

  receivedMessage$ = this.receivedMessageSource.asObservable();

  constructor(private httpClient: HttpClient) {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:7278/contactHub', {
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

      this.hubConnection.on('ReceiveMessage', (message) => {
        this.poruke.push(message);
        this.receivedMessageSource.next(message);
        console.log("Received message in AdminMessageService", message);
        console.log("Poruka subject", this.poruke)
      });
  }

  connectToSignalR(): Promise<void> {
    return this.hubConnection.start();
  }

  sendMessageToAdmin(message: string) {
    this.hubConnection.invoke('SendMessage', message);
    console.log(message)
  }


  closeConnection(): void {
    if (this.hubConnection.state === HubConnectionState.Connected) {
      this.hubConnection.stop();
      console.log('SignalR connection closed');
    }
  }


  getPorukeOdApija(): Observable<string[]> {
    return this.httpClient.get<string[]>("https://localhost:7278/api/messages");
  }

  getStoredMessages(): string[] {
    return this.poruke;
  }


}