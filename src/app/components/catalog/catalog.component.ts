import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/shared/auth.service';
import { CartService } from 'src/app/shared/cart-service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css'],
})
export class CatalogComponent implements OnInit {
  filterProizvod:string = '';
  proizvodi: any = null;
  editable:boolean =false;
  lokalniEmail:any=localStorage.getItem('email');
  odabraniProizvod: any = null;
  showModal = false;
  sortOpcije = [
    { value: 'cijena-asc', displayName: 'Lowest Price' },
    { value: 'cijena-desc', displayName: 'Highest Price' },
    { value: 'novo', displayName: 'New' },
    { value: 'polovno', displayName: 'Used' }
  ];
  odabranaSortOpcija = 'price-asc';
  searchResults: any[] = [];
  korisnikId!: string | null;
  maxKolicina: boolean = false;
  notLoggedIn: boolean = false;
  currentPage: number = 1;
  itemsPerPage: number = 3;
  total: number = 0;
  totalPages: number = 0;
  isSearchActive: boolean = false;
  disablePagination: boolean = false;

  constructor(private httpClient: HttpClient, 
    private route: ActivatedRoute, 
    private router: Router, 
    public authService: AuthService,
    private cartService: CartService){}

  /* testirajWebApi(): void {
    this.httpClient.get(
      "https://localhost:7278/" + "api/get-all-products"
    )
    .subscribe((x:any) => {
      this.proizvodi = x;

      this.proizvodi.forEach((proizvod: any) => {
        if (!proizvod.slikaProizvoda.startsWith("http")) {
          proizvod.slikaProizvoda = "https://localhost:7278/Images/" + proizvod.slikaProizvoda;
        }
      });
    });
  } */

  onPageChange(pageNumber: number) {
    this.currentPage = pageNumber;
    this.getProizvodiPaging();
  }

  calculateTotal(): void {
    this.httpClient
      .get(`https://localhost:7278/api/get-all-products`)
      .subscribe((res: any) => {
        this.total = res.length;
        this.totalPages = Math.ceil(this.total / this.itemsPerPage);
      });
  }

  getProizvodiPaging (): void {
    this.httpClient.get( "https://localhost:7278/" + `api/get-all-products-paging?pageNumber=${this.currentPage}&pageSize=${this.itemsPerPage}`)
    .subscribe(res => {
      this.proizvodi = res;
      this.proizvodi.forEach((proizvod: any) => {
        if (!proizvod.slikaProizvoda.startsWith("http")) {
          proizvod.slikaProizvoda = "https://localhost:7278/Images/" + proizvod.slikaProizvoda;
        }
      });
    });
  }

  getSortiraniProizvodi() {
    this.httpClient.get( "https://localhost:7278/" + `api/get-all-products-sorting?sortBy=${this.odabranaSortOpcija}`)
    .subscribe(res => {
      this.proizvodi = res;
      this.proizvodi.forEach((proizvod: any) => {
        if (!proizvod.slikaProizvoda.startsWith("http")) {
          proizvod.slikaProizvoda = "https://localhost:7278/Images/" + proizvod.slikaProizvoda;
        }
      });
    });
  }

  onSortChange() {
    this.getSortiraniProizvodi();
  }
  
  ngOnInit(): void {
   this.calculateTotal();
   /* this.getProizvodiPaging(); */
   this.authService.login(this.lokalniEmail);
   this.editable=false;
   this.korisnikId = this.authService.getKorisnikId();
   this.route.queryParams.subscribe((queryParams) => {
    this.filterProizvod = queryParams["proizvodSearch"] || '';
    this.search();
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

  changeEditState(): void {
      this.editable=!this.editable;
      if(this.editable==true)
      document.getElementById('accentEdit')!.innerHTML="Edit ON";
      else
      document.getElementById('accentEdit')!.innerHTML="Edit OFF";
   }

  search(): void {
    if (this.filterProizvod !== '') {
      this.httpClient.get<any[]>("https://localhost:7278/Search?proizvodSearch=" + this.filterProizvod)
        .subscribe((x: any[]) => {
          this.isSearchActive = true;
          this.proizvodi = x;
          this.proizvodi.forEach((proizvod: any) => {
            if (!proizvod.slikaProizvoda.startsWith("http")) {
              proizvod.slikaProizvoda = "https://localhost:7278/Images/" + proizvod.slikaProizvoda;
            }
          });
          const totalResults = this.proizvodi.length;
          this.disablePagination = totalResults <= this.itemsPerPage;
        });
    } else {
      this.isSearchActive = false;
      this.disablePagination = false;
      this.getProizvodiPaging();
    }
  }

  prikaziDetalje(p: any){
    this.odabraniProizvod = p;
    this.router.navigate(['/product-details', p.proizvodID]);
  }

  noviProizvod(){
    this.router.navigate(['/product-add']);
  }

  prikaziModal(p: any){
    this.odabraniProizvod = p;
    this.showModal = true;
  }

  obrisiProizvod() {
    this.httpClient.delete( "https://localhost:7278/api/delete/" + this.odabraniProizvod.proizvodID).subscribe(
      () => {
        const index = this.proizvodi.findIndex( p => p.proizvodID === this.odabraniProizvod.proizvodID);
        if (index !== -1) {
          this.proizvodi.splice(index, 1);
        }
        this.zatvoriModal();
      },
      error => {
        console.error('Error deleting product:', error);
        this.zatvoriModal();
      }
    );
    this.getProizvodiPaging();
  }

  zatvoriModal() {
    this.showModal = false;
    this.odabraniProizvod = null;
  }

  otkaziDelete() {
    this.zatvoriModal();
  }

}
