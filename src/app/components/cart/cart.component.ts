import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/auth.service';
import { CartService } from 'src/app/shared/cart-service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  korpa: any; 
  korisnikId!: string | null;
  korpaPrazna: boolean = false;
  ukupanIznos: number = 15;

  constructor(private httpClient: HttpClient, 
    private authService: AuthService,
    private cartService: CartService) {}

  ngOnInit() {
    this.korisnikId = this.authService.getKorisnikId();
    this.ucitajKorpaStavke();
  }

  ucitajKorpaStavke(){
    this.httpClient.get(
      "https://localhost:7278/" + `api/cart?korisnikId=${this.korisnikId}`
    ).subscribe((data: any) => {
      this.korpa = data;
      this.korpa.korpaStavke.forEach((korpaStavka: any) => {
        if (!korpaStavka.proizvod.slikaProizvoda.startsWith("http")) {
          korpaStavka.proizvod.slikaProizvoda = "https://localhost:7278/Images/" + korpaStavka.proizvod.slikaProizvoda;
        }
      });
      this.ukupnaCijena();
    },
    (error) => {
      console.log("Cart is empty, fill it up!")
      this.korpaPrazna = true;
    });
  }

  ukupnaCijena(): number {
    let ukupno = 0;
  
    if (this.korpa && this.korpa.korpaStavke && this.korpa.korpaStavke.length > 0) {
      ukupno = this.korpa.korpaStavke.reduce((acc: number, item: any) => {
        return acc + (item.proizvod.cijena * item.kolicina);
      }, 0);
    }
    return ukupno;
  }

  obrisiStavku(korpaStavkaId: number){
    this.httpClient.delete("https://localhost:7278/" + `api/obrisiStavku/${korpaStavkaId}`
    ).subscribe((res: any) => {
      alert("Cart item deleted from the cart successfully!");
      const trenutnaKolicina = res;
      this.cartService.updateCartItemCount(trenutnaKolicina);
      this.ucitajKorpaStavke();
    },
    (error) => {
      console.log("Nemoguce obrisati stavku.");
    })
  }
  
  updateKolicinu(korpaStavkaId: number, novaKolicina: number){
    this.httpClient.put("https://localhost:7278/" + `api/updateKolicinu/${korpaStavkaId}?kolicina=${novaKolicina}`, {})
    .subscribe((res:any) => {
      console.log("Kolicina narucenog proizvoda izmijenjena");
      this.ucitajKorpaStavke();
    },
    (error) => {
      console.log("Greska u mijenjanju kolicine narucenog proizvoda");
    })
  }

  povecajKolicinu(korpaStavka: any){
    if(korpaStavka.kolicina < korpaStavka.proizvod.kolicina){
      korpaStavka.kolicina++;
      this.updateKolicinu(korpaStavka.id, korpaStavka.kolicina);
      this.cartService.increaseCartItemCount();
    }
    else{
      console.log("Nema na stanju dovoljno proizvoda.");
    }
  }

  smanjiKolicinu(korpaStavka: any){
    if(korpaStavka.kolicina > 1){
      korpaStavka.kolicina--;
      this.updateKolicinu(korpaStavka.id, korpaStavka.kolicina);
      this.cartService.decreaseCartItemCount();
    }
  }
}
