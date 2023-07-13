import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  private apiUrl="https://localhost:7278/api/get-all-products";
  proizvod: any = null;
  constructor(private httpClient: HttpClient, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const proizvodID = params['id'];
      this.testirajWebApi(proizvodID);
      console.log(proizvodID)
     
    }); 
    console.log(this.proizvod)
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
      console.log(this.proizvod);
    });
  }

  formatiranjeOpisa(opis: string): string {
    if (opis) {
      const lines = opis.split('-').map(line => line.trim());
      return lines.join('<br>');
    }
    return '';
  }

}
