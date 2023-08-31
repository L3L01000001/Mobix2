import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { FormGroup, FormControl, Validators } from '@angular/forms';

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
  odabraniFile: File | null = null;
  proizvodForma: FormGroup;
  showAlert = false;

  constructor(private httpClient: HttpClient, private route: ActivatedRoute, private router: Router) {
    this.proizvodForma = new FormGroup({
      naziv: new FormControl('', Validators.required),
      opis: new FormControl('', Validators.required),
      stanje: new FormControl('', Validators.required),
      cijena: new FormControl('', Validators.required),
      slikaFile: new FormControl(null),
      kolicina: new FormControl('', Validators.required),
      dobavljacProizvodaID: new FormControl('', Validators.required),
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.proizvodIdentifikator = params['id'];
      this.getProizvodById(this.proizvodIdentifikator);
      console.log(this.proizvodIdentifikator);
      this.proizvodForma.patchValue(this.proizvod);
    }); 
   
  }

  getProizvodById(proizvodId: any){
    this.httpClient.get(
      "https://localhost:7278/" + "api/" + proizvodId
    )
    .subscribe((x:any) => {
      this.proizvod = x;
      if (!x.slikaProizvoda.startsWith("http")) {
          x.slikaProizvoda = "https://localhost:7278/Images/" + x.slikaProizvoda;
        }
      console.log(this.proizvod);
      this.proizvodForma.patchValue(this.proizvod);
    });
  }

  handleFileInput(event: any) {
    this.odabraniFile = event.target.files[0];
  }

  SaveChanges()
  {
    if (this.proizvodForma.invalid) {
      return;
    }
    const formData = new FormData();
    formData.append('naziv', this.proizvodForma.get('naziv')?.value || '');
    formData.append('opis', this.proizvodForma.get('opis')?.value || '');
    formData.append('stanje', this.proizvodForma.get('stanje')?.value || '');
    const cijena = this.proizvodForma.get('cijena')?.value;
    formData.append('cijena', cijena !== null ? cijena.toString() : '');
    const kolicina = this.proizvodForma.get('kolicina')?.value;
    formData.append('kolicina', kolicina !== null ? kolicina.toString() : '');
    const dobavljacProizvodaID = this.proizvodForma.get('dobavljacProizvodaID')?.value;
    formData.append('dobavljacProizvodaID', dobavljacProizvodaID !== null ? dobavljacProizvodaID.toString() : '');

    if (this.odabraniFile) {
      formData.append('slikaFile', this.odabraniFile, this.odabraniFile.name);
    }
    this.httpClient.put(`https://localhost:7278/api/edit-proizvod/${this.proizvod.proizvodID}`, formData).subscribe(
      (res) =>
      {
        console.log("Proizvod edited successfully.", this.proizvod)
        this.showAlert = true;
        setTimeout(() => {
          this.router.navigate(['/catalog']);
        }, 3000);
      },
      error => {
        console.error('Error editing product:', error);
      }
    )
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
