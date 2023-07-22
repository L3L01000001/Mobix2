import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {


  userIdentifikator:number=0;
  private apiUrl="https://localhost:7278/edit-user";
  user: any = null;
  odabraniUser=this.getUser();
  constructor(private httpClient: HttpClient, private route: ActivatedRoute, private router: Router) { }

  // ngOnInit(): void {
  //   this.route.params.subscribe(params => {
  //     const userId = params['id'];
  //     this.getUserById(userId);
  //     console.log(userId)
     
  //   }); 
  //   console.log(this.user)
  // }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.userIdentifikator = params['id'];
      this.getUserById(this.userIdentifikator);
      console.log(this.userIdentifikator);
     
    }); 
    console.log(this.user);
  }

  getUser():Observable<any>{
    return this.httpClient.get<any>(this.apiUrl);
  }

  getUserById(userId: any){
    this.httpClient.get(
      "https://localhost:7278/" + "get-user/" + userId
    )
    .subscribe((x:any) => {
      this.user = x;
      console.log(this.user);
    });
  }

  updateUser(userId: number, user: any): Observable<any> {
    return this.httpClient.put<any>(`${this.apiUrl}/${userId}`, user);
  }

  getPodaci(){
    return this.user;
  }

  SaveChanges()
  {
    // this.updateUser(this.userIdentifikator, this.user);
    
    this.updateUser(this.userIdentifikator, this.user).subscribe((res)=>{},
      error=>{
        console.error("User has not been updated.", error);
      }
    );
    alert("User has been updated");
    this.router.navigate(['/user-details']);
  }

}
