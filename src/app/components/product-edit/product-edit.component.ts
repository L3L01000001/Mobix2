import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

  proizvodIdentifikator:number=0;
  private apiUrl="https://localhost:7278/api/edit-proizvod";
  proizvod: any = null;
  izabraniDobavljac:any=null;
  svidobavljaci="https://localhost:7278/Dobavljac/get-all-dobavljaci";
  constructor(private httpClient: HttpClient, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.proizvodIdentifikator = params['id'];
      this.getProizvodById(this.proizvodIdentifikator);
      console.log(this.proizvodIdentifikator);
     
    }); 
    console.log(this.proizvod);
  }

  getProizvodById(proizvodId: any){
    this.httpClient.get(
      "https://localhost:7278/" + "api/" + proizvodId
    )
    .subscribe((x:any) => {
      this.proizvod = x;
      console.log(this.proizvod);
    });
  }

  updateProizvod(proizvodId: number, proizvod: any): Observable<any> {
    return this.httpClient.put<any>(`${this.apiUrl}/${proizvodId}`, proizvod);
  }

  SaveChanges()
  {
    // this.updateUser(this.userIdentifikator, this.user);
    
    this.updateProizvod(this.proizvodIdentifikator, this.proizvod).subscribe((res)=>{},
      error=>{
        console.error("Product has not been updated.", error);
      }
    );
    alert("Product has been updated");
    this.router.navigate(['/catalog']);
  }

  formatiranjeOpisa(opis: string): string {
    if (opis) {
      const lines = opis.split('-').map(line => line.trim());
      return lines.join('<br>');
    }
    return '';
  }

  getPodaci(){
    return this.proizvod;
  }


}
