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

  constructor(private adminMessageService: AdminMessageService) { }

  ngOnInit(): void {
  }

  submitForm(contactForm: NgForm){
    if (contactForm.valid) {
      const firstName = contactForm.value.fname;
      const lastName = contactForm.value.lname;
      const email = contactForm.value.email;
      const comment = contactForm.value.comment;

      const message = `Name: ${firstName} ${lastName}\nEmail: ${email}\nComment: ${comment}`;

      this.adminMessageService.connectionEstablished.subscribe(() => {
        this.adminMessageService.sendMessage(message);
        console.log("Poruka poslana")
      });

      console.log(message)
    

      contactForm.resetForm();
    }
  }

}
