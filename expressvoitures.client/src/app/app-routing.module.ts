import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageHomeComponent } from 'src/app/components/page-home/page-home.component';
import { PageCatalogueComponent } from 'src/app/components/page-catalogue/page-catalogue.component';
import { PageLoginComponent } from './components/page-admin/page-login/page-login.component';
import { PageContactComponent } from './components/page-contact/page-contact.component';
import { NotFoundComponent } from './components/not-found/not-found.component';

const routes: Routes = [
  { path: '', component: PageHomeComponent },
  { path: 'catalogue', component: PageCatalogueComponent },
  { path: 'contact', component: PageContactComponent },
  { path: 'admin/login', component: PageLoginComponent },
  { path: '**', pathMatch: 'full', component: NotFoundComponent }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
