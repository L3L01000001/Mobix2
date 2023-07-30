import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ActivatedRoute,Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedIn = false;
  adminUser=false;
  userName = '';
  getUserRole='';

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
    this.isLoggedIn = this.checkTokenValidity();
    this.userName = username;
    this.getUserRole=localStorage.getItem('role')!;
    console.log(this.getUserRole);
    if(this.getUserRole=="Admin")
      this.adminUser=true;
    // if(this.getUserRole=="Admin")
    //   this.adminUser=true;
    


    // this.http.post<any>('https://localhost:7278/api/Login', this.userName).subscribe(res=>{
    //   localStorage.setItem('token', res.token);
    //   localStorage.setItem('email', username);
    //   this.getUserRole=res.role;
    // })
  }

  checkAdminStatus():boolean{
    if(this.adminUser==true)
    return true;
    else
    return false;
  }

  logout() {
    this.http.post('https://localhost:7278/api/Logout', {}).subscribe(() => {
      this.isLoggedIn = false;
      this.userName = '';
      localStorage.removeItem('email');
      localStorage.removeItem('token');
      localStorage.removeItem('role');
      this.router.navigate(['/login']);
    });
  }


}