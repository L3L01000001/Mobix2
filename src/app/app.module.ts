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
    AdminComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NgSimpleCarouselModule,
    FormsModule,
    ReactiveFormsModule,
    JwtModule.forRoot(jwtOptions)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
