import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgSimpleCarouselModule } from 'ng-simple-carousel';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AboutComponent } from './components/about/about.component';
import { SampleComponent } from './components/carousel/carousel.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { IndexComponent } from './components/index/index.component';
import { HttpClientModule } from '@angular/common/http';
import { ContactComponent } from './components/contact/contact.component';
import { LoginComponent } from './components/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CatalogComponent } from './components/catalog/catalog.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { AdminComponent } from './components/admin/admin.component';
import {  JwtModule, JwtModuleOptions  } from '@auth0/angular-jwt';
import { CartComponent } from './components/cart/cart.component';
import { UserDetailsComponent } from './components/user-details/user-details.component';

import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';

import {MatInputModule} from '@angular/material/input';
import {NgFor} from '@angular/common';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import {Component} from '@angular/core';

import { ProductEditComponent } from './components/product-edit/product-edit.component';
import { UserEditComponent } from './components/user-edit/user-edit.component';
import { RegisterComponent } from './components/register/register.component';
import { ProductAddComponent } from './components/product-add/product-add.component';

const jwtOptions: JwtModuleOptions = {
  config: {
    tokenGetter: () => localStorage.getItem('token'),
    allowedDomains: ['https://localhost:4200'], // Replace with your API domain
    disallowedRoutes: ['https://localhost:4200/auth'] // Replace with any disallowed routes
  }
};

@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    AboutComponent,
    SampleComponent,
    ContactComponent,
    LoginComponent,
    CatalogComponent,
    ProductDetailsComponent,
    NavbarComponent,
    FooterComponent,
    AdminComponent,
    CartComponent,
    UserDetailsComponent,
    ProductEditComponent,
    UserEditComponent,
    RegisterComponent,
    ProductAddComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NgSimpleCarouselModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule, 
    MatDividerModule,
    JwtModule.forRoot(jwtOptions)
  ],
  exports:[
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
