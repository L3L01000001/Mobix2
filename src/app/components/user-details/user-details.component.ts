import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {

  filterKorisnik:string = '';
  korisnici: any = null;
  odabraniKorisnik: any = null;
  constructor(private httpClient: HttpClient, private route: ActivatedRoute, private router: Router){}

  testirajWebApi(): void {
    this.httpClient.get(
      "https://localhost:7278/get-all-users"
    )
    .subscribe((x:any) => {
      this.korisnici = x;
    });
  }
  
  ngOnInit(): void {
   this.testirajWebApi();
  }

  search(): void {
    if (this.filterKorisnik !== '') {
      this.httpClient.get<any[]>("https://localhost:7278/Search/korisnik?korisnikSearch=" + this.filterKorisnik)
        .subscribe((x: any[]) => {
          this.korisnici = x;
        });
    } else {
      this.testirajWebApi();
    }
  }

  handleSearchFromHome(searchQuery: string): void {
    if (searchQuery) {
      this.httpClient.get<any[]>("https://localhost:7278/Search/korisnik?korisnikSearch=" + searchQuery)
        .subscribe((x: any[]) => {
          this.korisnici = x;
        });
    }
  }

  prikaziDetalje(p: any){
    this.odabraniKorisnik = p;
    this.router.navigate(['/user-details', p.Id]);
  }

}
