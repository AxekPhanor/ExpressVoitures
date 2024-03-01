import { Component } from '@angular/core';
import { AnnonceService } from '../../services/annonce.service';
import { Annonce } from '../../models/annonce';

@Component({
  selector: 'page-catalogue',
  templateUrl: './page-catalogue.component.html',
  styleUrl: './page-catalogue.component.css'
})

export class PageCatalogueComponent {
  public annonces: Annonce[] = [];

  constructor(private annonceService: AnnonceService) {
    this.annonceService.getAllAvailable().subscribe(
      value => this.annonces = value as Annonce[]
    );
  }
}
