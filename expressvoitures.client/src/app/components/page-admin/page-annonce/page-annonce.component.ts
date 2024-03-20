/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component } from '@angular/core';
import { Annonce } from '../../../models/annonce';
import { Observable, of } from 'rxjs';
import { AnnonceService } from '../../../services/annonce.service';
import { FormAnnonceMajComponent } from '../../form-annonce-maj/form-annonce-maj.component';
import { MatDialog } from '@angular/material/dialog';
import { DialogDescriptionComponent } from '../../dialog-description/dialog-description.component';
import { SnackbarService } from '../../../services/snackbar.service';

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
    private dialog: MatDialog,
    private snackbar: SnackbarService) {
    this.getAll();
  }

  openDialogAnnonceMaj(element: Annonce) {
    this.dialog.open(FormAnnonceMajComponent, {
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
  }

  openDialogDescription(description: string) {
    this.dialog.open(DialogDescriptionComponent, {
      autoFocus: false,
      data: {
        description: description
      }
    });
  }

  vendre(element: Annonce) {
    this.annonceService.vendu(element.id).subscribe({
      next: () => {
        this.snackbar.green('Annonce vendue');
        window.location.href = '/admin/annonces';
      },
      error: () => {
        this.snackbar.red('Une erreur est survenue lors de la vente de l\'annonce');
      }
    });
  }

  getAll() {
    this.annonceService.getAll().subscribe({
      next: value => {
        this.annonce = value as Annonce[];
        this.annonceObservable = of(this.annonce.map(annonce => annonce));
      },
      error: () => {
        this.snackbar.red('Une erreur est survenue lors de la récupération des annonces');
      }
    });
  }
}
