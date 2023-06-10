import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent implements OnInit {
  filterProizvod:string = '';
  proizvodi: any = null;
  odabraniProizvod: any = null;
  constructor(private httpClient: HttpClient, private route: ActivatedRoute, private router: Router){}

  testirajWebApi(): void {
    this.httpClient.get(
      "https://localhost:7278/" + "api/get-all-products"
    )
    .subscribe((x:any) => {
      this.proizvodi = x;
    });
  }
  
  ngOnInit(): void {
   this.testirajWebApi();
  }

  search(): void {
    if (this.filterProizvod !== '') {
      this.httpClient.get<any[]>("https://localhost:7278/Search?proizvodSearch=" + this.filterProizvod)
        .subscribe((x: any[]) => {
          this.proizvodi = x;
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

}
