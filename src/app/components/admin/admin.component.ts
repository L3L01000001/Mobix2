import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  odabraniUser: any = null;
  adminEmail:string|null=null;
  constructor(private httpClient: HttpClient, private route: ActivatedRoute, private router: Router) { }

  testirajWebApi(): void {
    this.httpClient.get(
      "https://localhost:7278/" + "api/get-all-users"
    )
    .subscribe((x:any) => {
      this.odabraniUser = x;
    });
  }
  
  ngOnInit(): void {
   this.testirajWebApi();
  }

}
