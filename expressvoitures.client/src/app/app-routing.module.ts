import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageHomeComponent } from 'src/app/components/page-home/page-home.component';
import { PageCatalogueComponent } from 'src/app/components/page-catalogue/page-catalogue.component';
import { PageLoginComponent } from './components/page-admin/page-login/page-login.component';
import { PageContactComponent } from './components/page-contact/page-contact.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { PageDetailAnnonceComponent } from './components/page-detail-annonce/page-detail-annonce.component';
import { PageVoitureComponent } from './components/page-admin/page-voiture/page-voiture.component';
import { PageLogoutComponent } from './components/page-admin/page-logout/page-logout.component';
import { isAdminGuard } from './is-admin.guard';
import { PageAnnonceComponent } from './components/page-admin/page-annonce/page-annonce.component';
import { FormNewPasswordComponent } from './components/form-new-password/form-new-password.component';

const routes: Routes = [
  { path: '', component: PageHomeComponent },
  { path: 'catalogue', component: PageCatalogueComponent },
  { path: 'catalogue/detail-annonce/:id', component: PageDetailAnnonceComponent },
  { path: 'contact', component: PageContactComponent },
  { path: 'admin/login', component: PageLoginComponent },
  { path: 'admin/logout', component: PageLogoutComponent, canActivate: [isAdminGuard] },
  { path: 'admin/voitures', component: PageVoitureComponent, canActivate: [isAdminGuard] },
  { path: 'admin/annonces', component: PageAnnonceComponent, canActivate: [isAdminGuard] },
  { path: 'admin/reset-password', component: FormNewPasswordComponent, canActivate: [isAdminGuard] },
  { path: '**', pathMatch: 'full', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
