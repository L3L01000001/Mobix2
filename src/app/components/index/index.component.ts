import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ConfigService } from 'src/app/config/config.service';
import { SampleComponent } from '../carousel/carousel.component';
import { NgSimpleCarouselModule } from 'ng-simple-carousel/lib/carousel.module';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  filterProizvod:string = '';
  proizvodi: any = null;
  constructor(private httpClient: HttpClient, private router: Router){}

  testirajWebApi(): void {
   
  }

  ngOnInit(): void {
  }

  search(): void {
    if (this.filterProizvod !== '') {
      this.httpClient.get<any[]>("https://localhost:7278/Search?proizvodSearch=" + this.filterProizvod)
        .subscribe((x: any[]) => {
          this.proizvodi = x;
          console.log("search results:", x)
        });
    } else {
      this.router.navigate(['/catalog']);
    }
  } 
}

  

