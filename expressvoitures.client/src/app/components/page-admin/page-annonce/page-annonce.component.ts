/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component } from '@angular/core';
import { Annonce } from '../../../models/annonce';
import { Observable, of } from 'rxjs';
import { AnnonceService } from '../../../services/annonce.service';
import { FormAnnonceMajComponent } from '../../form-annonce-maj/form-annonce-maj.component';
import { MatDialog } from '@angular/material/dialog';
import { DialogDescriptionComponent } from '../../dialog-description/dialog-description.component';

@Component({
  selector: 'app-page-annonce',
  templateUrl: './page-annonce.component.html',
  styleUrl: './page-annonce.component.css'
})
export class PageAnnonceComponent {
  annonce: Annonce[] = [];
  annonceObservable: Observable<Annonce[]> = new Observable<Annonce[]>();
  displayedColumns: string[] = ['titre', 'description', 'photos', 'dateCreation', 'PrixVente', 'dateVente', 'mettreAJour', 'vendre'];

  constructor(private annonceService: AnnonceService,
    private dialog: MatDialog) {
    this.getAll();
  }

  openDialogAnnonceMaj(element: Annonce) {
    const dialogRef = this.dialog.open(FormAnnonceMajComponent, {
      autoFocus: false,
      disableClose: true,
      data: {
        id: element.id,
        voitureEnregistreId: element.voitureEnregistreId,
        titre: element.titre,
        description: element.description,
        photos: element.photos,
        prixVente: element.prixVente
      }
    });
    dialogRef.afterClosed().subscribe(() => {
      console.log('The dialog was closed');
    });
  }

  openDialogDescription(description: string) {
    const dialogRef = this.dialog.open(DialogDescriptionComponent, {
      autoFocus: false,
      data: {
        description: description
      }
    });
    dialogRef.afterClosed().subscribe(() => {
      console.log('The dialog was closed');
    });
  }

  vendre(element: Annonce) {
    this.annonceService.vendu(element.id).subscribe({
      next: () => {
        console.log('Annonce vendue');
        window.location.href = '/admin/annonces';
      },
      error: err => {
        console.error('Une erreur est survenue lors de la vente de l\'annonce', err);
      }
    });
  }

  getAll() {
    this.annonceService.getAll().subscribe({
      next: value => {
        this.annonce = value as Annonce[];
        this.annonceObservable = of(this.annonce.map(annonce => annonce));
      },
      error: err => {
        console.error('Une erreur est survenue lors de la récupération des annonces', err);
      }
    });
  }
}
