import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute,Router } from '@angular/router';
import { AuthService } from 'src/app/shared/auth.service';

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
  username: string = '';
  constructor(private httpClient: HttpClient, private route: ActivatedRoute, private router: Router, private authService:AuthService) { }

  ngOnInit(): void {
  }

  btnLogin(){
    this.httpClient.post<any>("https://localhost:7278/api/Login", this.model)
    .subscribe(res=>{
      console.log(res)
      localStorage.setItem('token', res.token);
      localStorage.setItem('email',this.model.email);
      console.log(res.token)
      this.authService.login(this.model.email);
       if (res.role === 'Admin') {
        alert('Uspješan  '+this.model.email);
        this.isAdmin=true;
        // console.log("Admin");
        this.router.navigate(['/admin']);
      } else if (res.role === 'Korisnik') {
        this.router.navigate(['/user']);
        console.log("User");
        this.router.navigate(['/admin']);
      } else {
        alert('Uspješan login '+this.model.email);
        this.router.navigate(['/admin']);

      }
      },
      (error) => {
        alert('Pogresan login');
        this.model.email='';
        this.model.password='';
        console.log("Pogresne login informacije", error)
        this.router.navigate(['/login']);
      });
    }
  }


