import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/shared/auth.service';
import { AdminMessageService } from '../../shared/admin-message.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  zaprimljenePoruke: string[] = [];
  odabraniUser: any = null;
  adminEmail:string|null=null;
  dozvoljeno:boolean=false;
  constructor(private adminMessageService: AdminMessageService, private httpClient: HttpClient, private route: ActivatedRoute, private router: Router, public authService: AuthService) {
    this.adminMessageService.zaprimljenaPoruka.subscribe((message: string) => {
      this.zaprimljenePoruke.push(message);
    });
   }

  // testirajWebApi(): void {
  //   this.httpClient.get(
  //     "https://localhost:7278/" + "api/get-all-users"
  //   )
  //   .subscribe((x:any) => {
  //     this.odabraniUser = x;
  //   });
  // }
  
  ngOnInit(): void {
    if(this.authService.getUserRole=="Admin")
      this.dozvoljeno=true;
    else
      this.dozvoljeno=false;
  }

  showAdminMessages: boolean = false;

  toggleAdminMessagesDropdown() {
    this.showAdminMessages = !this.showAdminMessages;
  }

}
