import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ActivatedRoute,Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedIn = false;
  userName = '';

  constructor(private jwtHelper: JwtHelperService, private http: HttpClient, private router: Router) {
    this.isLoggedIn = this.checkTokenValidity();
  }

  checkTokenValidity(): boolean {
    const token = localStorage.getItem('token');
    if (!token) {
      return false;
    }
    if (!this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    return false;
  }

  login(username: string) {
    this.isLoggedIn = true;
    this.userName = username;
  }

  logout() {
    this.http.post('https://localhost:7278/api/Logout', {}).subscribe(() => {
      this.isLoggedIn = false;
      this.userName = '';
      localStorage.removeItem('email');
      localStorage.removeItem('token');
      this.router.navigate(['/login']);
    });
  }
}