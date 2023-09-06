import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/shared/auth.service';
import { CartService } from 'src/app/shared/cart-service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  private apiUrl="https://localhost:7278/api/get-all-products";
  proizvod: any = null;
  maxKolicina: boolean = false;
  notLoggedIn: boolean = false;
  korisnikId!: string | null;
  constructor(private httpClient: HttpClient, private route: ActivatedRoute, 
    public authService: AuthService,
    private cartService: CartService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const proizvodID = params['id'];
      this.testirajWebApi(proizvodID);
    }); 
    this.korisnikId = this.authService.getKorisnikId();
  }

  getProizvodi():Observable<any>{
    return this.httpClient.get<any>(this.apiUrl);
  }

  testirajWebApi(proizvodID: any){
    this.httpClient.get(
      "https://localhost:7278/" + "api/" + proizvodID
    )
    .subscribe((x:any) => {
      this.proizvod = x;

        if (!x.slikaProizvoda.startsWith("http")) {
          x.slikaProizvoda = "https://localhost:7278/Images/" + x.slikaProizvoda;
        }
      console.log(this.proizvod);
    });
  }

  dodajUKorpu(proizvodID: number){
    if (!this.authService.isLoggedIn) {
      this.notLoggedIn = true;
      setTimeout(() => {
        this.notLoggedIn=false;
      }, 3000);
      return;
    }
    this.httpClient.post("https://localhost:7278" + `/api/dodaj?korisnikID=${this.korisnikId}&proizvodID=${proizvodID}`, {})
    .subscribe(
      (res: any) => {
        const totalKolicina = res;
        this.cartService.updateCartItemCount(totalKolicina);
        console.log('Product added to cart:', res);
        alert("Product added to cart!");
      },
      (error) => {
        this.maxKolicina = true;
        setTimeout(() => {
          this.maxKolicina=false;
        }, 3000);
      }
    );
  }

  formatiranjeOpisa(opis: string): string {
    if (opis) {
      const lines = opis.split('-').map(line => line.trim());
      return lines.join('<br>');
    }
    return '';
  }

}
