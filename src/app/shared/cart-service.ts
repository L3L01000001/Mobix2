import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private cartItemCountSubject = new BehaviorSubject<number>(0);
  korpa: any;

  constructor(private httpClient: HttpClient) {}

  getCartItemCount(): Observable<number> {
    return this.cartItemCountSubject.asObservable();
  }

  updateCartItemCount(count: number): void {
    this.cartItemCountSubject.next(count);
  }

  updateCartItemCountUser(korisnikId: string): void {
    this.httpClient.get( "https://localhost:7278" + `/api/cart?korisnikId=${korisnikId}`).subscribe(res => {
        this.korpa = res;
        let ukupno = 0;
        ukupno = this.korpa.korpaStavke.reduce((acc: number, item: any) => {
          return acc + item.kolicina;
        }, 0);
        this.updateCartItemCount(ukupno);
    });
  }

  increaseCartItemCount(): void {
    const currentCount = this.cartItemCountSubject.value;
    this.updateCartItemCount(currentCount + 1);
  }

  decreaseCartItemCount(): void {
    const currentCount = this.cartItemCountSubject.value;
    if (currentCount > 0) {
      this.updateCartItemCount(currentCount - 1);
    }
  }
}