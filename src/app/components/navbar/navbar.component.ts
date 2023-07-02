import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit{
  isEnglish:boolean=true;
  isBosnian:any;
  activeRoute: string = "";
  email:any="";

  constructor(private router: Router, private authService:AuthService) {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.activeRoute = event.url;
      }
    });
  }

  ngOnInit(): void {
    this.email=this.authService.getUserEmail();
  }

  isLoggedIn():boolean
  {
    return !!this.email;
  }

  title = 'Mobix';
  bosnianFooter: any;
}
