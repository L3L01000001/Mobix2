import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit{
  proizvodForma: FormGroup;
  odabraniFile: File | null = null;

  constructor(private httpClient: HttpClient, private router: Router) {
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

  ngOnInit(): void {}

  onFileChange(event: any): void {
    this.odabraniFile = event.target.files[0];
  }

  onSubmit(): void {
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

    this.httpClient.post<any>('https://localhost:7278/api/add-product', formData).subscribe(
      (response: any) => {
        alert("Proizvod uspjesno dodan!");
        console.log('Product added successfully.', response);
      },
      (error) => {
        console.error('Failed to add the product:', error);
      }
    );
    this.router.navigate(['/catalog']);
  }

}
