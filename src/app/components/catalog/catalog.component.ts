import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/shared/auth.service';

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
  constructor(private httpClient: HttpClient, private route: ActivatedRoute, private router: Router, public authService: AuthService){}

  testirajWebApi(): void {
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
  }

  currentPage: number = 1;
  itemsPerPage: number = 3;
  total: number = 0;
  totalPages: number = 0;
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
  
  ngOnInit(): void {
   this.calculateTotal();
   this.getProizvodiPaging();
   this.authService.login(this.lokalniEmail);
   this.editable=false;
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
          this.proizvodi = x;
          this.proizvodi.forEach((proizvod: any) => {
            if (!proizvod.slikaProizvoda.startsWith("http")) {
              proizvod.slikaProizvoda = "https://localhost:7278/Images/" + proizvod.slikaProizvoda;
            }
          });
        });
    } else {
      this.testirajWebApi();
    }
  }

  handleSearchFromHome(searchQuery: string): void {
    if (searchQuery) {
      this.httpClient.get<any[]>("https://localhost:7278/Search?proizvodSearch=" + searchQuery)
        .subscribe((x: any[]) => {
          this.proizvodi = x;
        });
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
    this.testirajWebApi();
  }

  zatvoriModal() {
    this.showModal = false;
    this.odabraniProizvod = null;
  }
  otkaziDelete() {
    this.zatvoriModal();
  }

}
