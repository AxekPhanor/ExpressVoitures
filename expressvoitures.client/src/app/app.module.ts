import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatButtonModule } from '@angular/material/button';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { AsyncPipe } from '@angular/common';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';

import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { PageHomeComponent } from './components/page-home/page-home.component';
import { PageCatalogueComponent } from './components/page-catalogue/page-catalogue.component';
import { PageLoginComponent } from './components/page-admin/page-login/page-login.component';
import { PageContactComponent } from './components/page-contact/page-contact.component';
import { PageDetailAnnonceComponent } from './components/page-detail-annonce/page-detail-annonce.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { PageVoitureComponent } from './components/page-admin/page-voiture/page-voiture.component';
import { PageAnnonceComponent } from './components/page-admin/page-annonce/page-annonce.component';
import { FormVoitureCreateComponent } from './components/form-voiture-create/form-voiture-create.component';
import { FormVoitureMajComponent } from './components/form-voiture-maj/form-voiture-maj.component';
import { FormAnnonceCreateComponent } from './components/form-annonce-create/form-annonce-create.component';
import { FormAnnonceMajComponent } from './components/form-annonce-maj/form-annonce-maj.component';
import { DialogDescriptionComponent } from './components/dialog-description/dialog-description.component';

@NgModule({
  declarations: [
    AppComponent,
    PageHomeComponent,
    PageCatalogueComponent,
    PageLoginComponent,
    PageContactComponent,
    PageDetailAnnonceComponent,
    PageVoitureComponent,
    PageAnnonceComponent,
    FormVoitureCreateComponent,
    FormVoitureMajComponent,
    FormAnnonceCreateComponent,
    FormAnnonceMajComponent,
    DialogDescriptionComponent
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
    MatCardModule,
    FormsModule,
    SidebarComponent,
    MatTableModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatAutocompleteModule,
    ReactiveFormsModule,
    AsyncPipe,
    MatButtonModule,
    MatDialogModule,
    MatGridListModule,
    MatDatepickerModule,
    MatNativeDateModule 
  ],
  providers: [
    provideAnimationsAsync(),
    MatDatepickerModule,
    { provide: MAT_DATE_LOCALE, useValue: 'fr-FR' },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
