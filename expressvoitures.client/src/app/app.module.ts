import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatButtonModule } from '@angular/material/button';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { MatCardModule } from '@angular/material/card';


import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { PageHomeComponent } from './components/page-home/page-home.component';
import { PageCatalogueComponent } from './components/page-catalogue/page-catalogue.component';
import { PageLoginComponent } from './components/page-admin/page-login/page-login.component';
import { PageContactComponent } from './components/page-contact/page-contact.component';

@NgModule({
  declarations: [
    AppComponent,
    PageHomeComponent,
    PageCatalogueComponent,
    PageLoginComponent,
    PageContactComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    MatSlideToggleModule,
    MatButtonModule,
    NavbarComponent,
    RouterOutlet,
    RouterLink,
    RouterLinkActive,
    MatCardModule
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
