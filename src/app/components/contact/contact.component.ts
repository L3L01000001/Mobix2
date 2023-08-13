import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { AdminMessageService } from '../../shared/admin-message.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  formData = {
    fname: '',
    lname: '',
    email: '',
    comment: '',
  };
  showAlert = false;

  constructor(private adminMessageService: AdminMessageService) { }

  ngOnInit(): void {
  }


  submitForm(contactForm: NgForm){
    if (contactForm.valid) {
      const firstName = contactForm.value.fname;
      const lastName = contactForm.value.lname;
      const email = contactForm.value.email;
      const comment = contactForm.value.comment;

      const message = `${firstName} ${lastName} (${email}): ${comment}`;

      this.adminMessageService.sendMessageToAdmin(message);

      console.log(message)

      contactForm.resetForm();
    }
    this.showAlert = true;

    setTimeout(() => {
            this.hideAlert();
    }, 3000);
  }
  
  hideAlert() {
    this.showAlert = false;
  }
}
