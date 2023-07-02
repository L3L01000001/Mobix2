import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private email!: string;
  constructor() { 
  }

  setUserEmail(email: string): void {
    this.email = email;
  }

  getUserEmail(): string {
    return this.email;
  }
}
