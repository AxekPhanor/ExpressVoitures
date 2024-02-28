import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageHomeComponent } from 'src/app/components/page-home/page-home.component';
import { PageCatalogueComponent } from 'src/app/components/page-catalogue/page-catalogue.component';

const routes: Routes = [
  { path: '', component: PageHomeComponent },
  { path: 'catalogue', component: PageCatalogueComponent }
  // autres routes...
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
