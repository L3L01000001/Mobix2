import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model= {
  email: '',
  password: ''
  }
  rememberMe: any;
  isAdmin: boolean = false;
  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }

  btnLogin(){
    this.http.post<any>("https://localhost:7278/api/Login", this.model)
    .subscribe(res=>{
       if (res.role === 'Admin') {
        this.router.navigate(['/admin']);
        console.log("Admin")
      } else if (res.role === 'Korisnik') {
        this.router.navigate(['/user']);
        console.log("User")
      } else {
        console.log("Pogresne login informacije")
      }
      },
      (error) => {
        console.error('Login failed:', error);
      });
    }
  }


