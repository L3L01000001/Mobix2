import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { AuthService } from 'src/app/shared/auth.service';
import { CartService } from 'src/app/shared/cart-service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit{
  isEnglish:boolean=true;
  isBosnian:any;
  activeRoute: string = "";
  dozvoljenAdmin:boolean=false;
  email:any="";
  isMenuOpen: boolean = false;
  brojProizvodaUKorpi: number = 0;
  korisnikId!: string | null;
  korpa: any; 
  cartItemCount: number = 0;

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }

  constructor(private router: Router,private httpClient: HttpClient, public authService:AuthService, private cartService:CartService) {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.activeRoute = event.url;
      }
    });
  }

  ngOnInit(): void {
   this.email = localStorage.getItem('email');
   var roleUser=localStorage.getItem('role');
   if(roleUser=="Admin"){
    this.dozvoljenAdmin=true;
    }
   this.authService.login(this.email);
   this.korisnikId = this.authService.getKorisnikId();
   this.getProizvodiUKorpi();
   this.cartService.getCartItemCount().subscribe((count) => {
    this.cartItemCount = count;
  });
  }

  getProizvodiUKorpi (): void {
    this.httpClient.get( "https://localhost:7278/" + `api/cart?korisnikId=${this.korisnikId}`)
    .subscribe(res => {
      this.korpa = res;
      let ukupno = 0;
      ukupno = this.korpa.korpaStavke.reduce((acc: number, item: any) => {
        return acc + item.kolicina;
      }, 0);
      this.cartService.updateCartItemCount(ukupno);
    });
  }

  btnLogout(){
    this.authService.logout();
    localStorage.removeItem('email');
    localStorage.removeItem('token');
    localStorage.removeItem('role');
  }

  title = 'Mobix';
  bosnianFooter: any;
}
