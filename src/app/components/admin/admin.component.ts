import { HttpClient } from '@angular/common/http';
import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/shared/auth.service';
import { AdminMessageService } from '../../shared/admin-message.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit, OnDestroy {
  receivedMessages: string[] = [];
  receivedMessageSubscription: Subscription | undefined;
  odabraniUser: any = null;
  adminEmail:string|null=null;
  dozvoljeno:boolean=false;
  constructor(private adminMessageService: AdminMessageService, private httpClient: HttpClient, private route: ActivatedRoute, private router: Router, public authService: AuthService) {}


  // testirajWebApi(): void {
  //   this.httpClient.get(
  //     "https://localhost:7278/" + "api/get-all-users"
  //   )
  //   .subscribe((x:any) => {
  //     this.odabraniUser = x;
  //   });
  // }
  
  ngOnInit(): void {
    if (this.authService.getUserRole === "Admin") {
      this.dozvoljeno = true;
      this.adminMessageService.getPorukeOdApija().subscribe(messages => {
        this.receivedMessages = messages;
      });

    this.receivedMessageSubscription = this.adminMessageService.receivedMessage$.subscribe(message => {
      this.receivedMessages.push(message);
    });
      /* this.adminMessageService.getPorukeOdApija().subscribe(
        (messages) => {
          this.receivedMessages = messages;
          console.log(this.receivedMessages)
        },
        (error) => {
          console.error('Error fetching received messages:', error);
        }
      ); */
    } else {
      this.dozvoljeno = false;
    }
  }

  ngOnDestroy(): void {
    if (this.receivedMessageSubscription) {
      this.receivedMessageSubscription.unsubscribe();
    }
  }

  showAdminMessages: boolean = false;

  toggleAdminMessagesDropdown() {
    this.showAdminMessages = !this.showAdminMessages;
  }

  extractEmailAddressFromMessage(message: string): string | null {
    const emailRegex = /[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}/;
    const match = message.match(emailRegex);
    
    if (match && match.length > 0) {
        return match[0];
    } else {
        return null;
    }
}

}
