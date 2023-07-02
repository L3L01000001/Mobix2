import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute,Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';

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
  constructor(private httpClient: HttpClient, private route: ActivatedRoute, private router: Router, private authService:AuthService) { }

  ngOnInit(): void {
  }

  btnLogin(){
    this.httpClient.post<any>("https://localhost:7278/api/Login", this.model)
    .subscribe(res=>{
       if (res.role === 'Admin') {
        alert('Uspješan  '+this.model.email);
        this.isAdmin=true;
        // console.log("Admin");
        localStorage.setItem('email',this.model.email);
        this.authService.setUserEmail(this.model.email);
        this.router.navigate(['/admin', this.model.email]);
      } else if (res.role === 'Korisnik') {
        this.router.navigate(['/user']);
        console.log("User");
        this.router.navigate(['/admin', this.model.email]);
      } else {
        

        alert('Uspješan login '+this.model.email);
        localStorage.setItem('email',this.model.email);
        this.authService.setUserEmail(this.model.email);
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


