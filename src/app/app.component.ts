import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, NavigationEnd } from '@angular/router';
import { AuthService } from 'src/app/shared/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CartService } from './shared/cart-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],

})
export class AppComponent implements OnInit {
  isEnglish:boolean=true;
  isBosnian:any;
  activeRoute: string = "";

  constructor(private router: Router, 
    private authService: AuthService,
    private cartService: CartService,
    private httpClient: HttpClient,) {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.activeRoute = event.url;
      }
    });
  }

  ngOnInit() {
    this.authService.isLoggedIn = this.authService.checkTokenValidity();
  }

  title = 'Mobix';
  bosnianFooter: any;

}
