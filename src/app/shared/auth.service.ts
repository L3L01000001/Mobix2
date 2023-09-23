import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ActivatedRoute,Router } from '@angular/router';
import { CartService } from './cart-service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedIn = false;
  adminUser=false;
  userName = '';
  getUserRole='';
  korisnikId: string | null = null;

  constructor(private jwtHelper: JwtHelperService, private http: HttpClient, private router: Router, private cartService: CartService) {
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
    localStorage.removeItem('email');
    localStorage.removeItem('token');
    localStorage.removeItem('role');
    localStorage.removeItem('id');
    return false;
  }

  setKorisnikId() {
    this.korisnikId = localStorage.getItem('id');
  }
  

  login(username: string) {
    this.isLoggedIn = this.checkTokenValidity();
    this.userName = username;
    this.getUserRole=localStorage.getItem('role')!;
    this.setKorisnikId();
    this.cartService.updateCartItemCountUser(this.korisnikId ?? '');
    if(this.getUserRole=="Admin")
      this.adminUser=true;
    else if (this.getUserRole=="Korisnik")
      this.adminUser=false;
    else 
      this.adminUser=false;
  }

  checkAdminStatus():boolean{
    if(this.adminUser==true)
    return true;
    else
    return false;
  }

  logout() {
    this.http.post('https://localhost:7278/api/Logout', {}).subscribe(() => {
      this.cartService.updateCartItemCount(0);
      this.isLoggedIn = false;
      this.userName = '';
      localStorage.removeItem('email');
      localStorage.removeItem('token');
      localStorage.removeItem('role');
      localStorage.removeItem('id');
      this.adminUser=false;
      this.router.navigate(['/login']);
    });
  }

  getKorisnikId(): string | null {
    return this.korisnikId;
  }
}