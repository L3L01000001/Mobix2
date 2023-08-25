import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute,Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
    model= {
      ime: '',
      prezime: '',
      email: '',
      password: '',
      confirmPassword: ''
    }

    validationErrors: any = {};
    constructor(private httpClient: HttpClient, private route: ActivatedRoute, private router: Router) { }
  
    ngOnInit(): void {
    }
  
    btnRegister(){
      this.httpClient.post<any>("https://localhost:7278/api/register", this.model)
      .subscribe(res=>{
          console.log("Uspjesna registracija!")
          this.router.navigate(['/registration-success']);
        },
        (error: HttpErrorResponse) => {
          if (error.status === 400) {
            this.validationErrors = error.error.errors;
            console.log(this.validationErrors)
          } else {
            console.log('An error occurred during registration', error);
          }
        });
      }

}
