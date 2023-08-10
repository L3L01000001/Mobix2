import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-admin-messages',
  templateUrl: './admin-messages.component.html',
  styleUrls: ['./admin-messages.component.css']
})
export class AdminMessagesComponent {
  @Input() zaprimljenePoruke: string[] = []; 

  constructor() { }

  // Implement methods or logic related to displaying messages
}