import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FormVoitureCreateComponent } from '../../form-voiture-create/form-voiture-create.component';
import { VoitureEnregistre } from '../../../models/voitureEnregistre';
import { VoitureEnregistreService } from '../../../services/voiture-enregistre.service';
import { Observable, of } from 'rxjs';
import { FormVoitureMajComponent } from '../../form-voiture-maj/form-voiture-maj.component';
import { FormAnnonceCreateComponent } from '../../form-annonce-create/form-annonce-create.component';

@Component({
  selector: 'page-voiture',
  templateUrl: './page-voiture.component.html',
  styleUrl: './page-voiture.component.css'
})
export class PageVoitureComponent {
  voitureEnregistres: VoitureEnregistre[] = [];
  voitureEnregistreObservable: Observable<VoitureEnregistre[]> = new Observable<VoitureEnregistre[]>();
  displayedColumns: string[] = ['voiture', 'dateAchat', 'prixAchat', 'reparations', 'coutReparations', 'creerAnnonce', 'mettreAJour'];
  constructor(private dialog: MatDialog,
    private voitureEnregistreService: VoitureEnregistreService)
  {
    this.getAll();
  }

  openDialogCreate() {
    const dialogRef = this.dialog.open(FormVoitureCreateComponent,
    {
      autoFocus: false,
      disableClose: true
    });
    dialogRef.afterClosed().subscribe(() => {
      console.log('The dialog was closed');
    });
  }

  openDialogMaj(element: VoitureEnregistre) {
    const dialogRef = this.dialog.open(FormVoitureMajComponent, {
      autoFocus: false,
      disableClose: true,
      data: {
        voitureEnregistre: {
          id: element.id,
          voitureId: element.voitureId,
          voiture: element.voiture,
          dateAchat: element.dateAchat,
          prixAchat: element.prixAchat,
          reparations: element.reparations,
          coutReparations: element.coutReparations
        }
      }
    });
    dialogRef.afterClosed().subscribe(() => {
      console.log('The dialog was closed');
    });
  }

  openDialogAnnonceCreate(element: VoitureEnregistre) {
    const dialogRef = this.dialog.open(FormAnnonceCreateComponent, {
      autoFocus: false,
      disableClose: true,
      data: {
        voitureEnregistre: {
          id: element.id,
          voitureId: element.voitureId,
          voiture: element.voiture,
        }
      }
    });
    dialogRef.afterClosed().subscribe(() => {
      console.log('The dialog was closed');
    });
  }

  getAll() {
    this.voitureEnregistreService.getAll().subscribe({
      next: value => {
        this.voitureEnregistres = value as VoitureEnregistre[];
        this.voitureEnregistreObservable = of(this.voitureEnregistres.map(voitureEnregistre => voitureEnregistre));
      },
      error: err => {
        console.error('Une erreur est survenue lors de la récupération des voitures enregistrées', err);
      }
    });
  }
}
