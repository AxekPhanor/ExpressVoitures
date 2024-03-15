/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { VoitureService } from '../../services/voiture.service';
import { Voiture } from '../../models/voiture';
import { VoitureEnregistreService } from '../../services/voiture-enregistre.service';
import { VoitureEnregistre } from '../../models/voitureEnregistre';
import { DateAdapter } from '@angular/material/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SnackbarService } from '../../services/snackbar.service';

@Component({
  selector: 'app-form-voiture-maj',
  templateUrl: './form-voiture-maj.component.html',
  styleUrl: './form-voiture.component.css'
})
export class FormVoitureMajComponent {
  formVoiture = new FormGroup({
    controlMarque: new FormControl('', Validators.compose([
      Validators.pattern('^[a-zA-Z]*$'),
      Validators.required,
    ])),
    controlModele: new FormControl('', Validators.compose([
      Validators.pattern('^[a-zA-Z]*$'),
      Validators.required,
    ])),
    controlAnnee: new FormControl('', Validators.compose([
      Validators.pattern('^[0-9]*$'),
      Validators.min(1990),
      Validators.max(new Date().getFullYear()),
      Validators.required,
    ])),
    controlFinition: new FormControl('', Validators.compose([
      Validators.pattern('^[a-zA-Z]*$'),
      Validators.required,
    ])),
    controlDateAchat: new FormControl('', Validators.compose([
      Validators.required,
    ])),
    controlPrixAchat: new FormControl('', Validators.compose([
      Validators.pattern('^[0-9]*$'),
      Validators.required,
    ])),
    controlReparations: new FormControl('', Validators.compose([
      Validators.required,
    ])),
    controlCoutReparations: new FormControl('', Validators.compose([
      Validators.pattern('^[0-9]*$'),
      Validators.required,
    ])),
  });

  voitures: Voiture[] = [];
  voitureEnregistre: VoitureEnregistre = new VoitureEnregistre();

  filteredMarques: Observable<string[]> = new Observable<string[]>();
  filteredAnnees: Observable<string[]> = new Observable<string[]>();
  filteredModeles: Observable<string[]> = new Observable<string[]>();
  filteredFinitions: Observable<string[]> = new Observable<string[]>();

  constructor(private voitureService: VoitureService,
    private voitureEnregistreService: VoitureEnregistreService,
    private _adapter: DateAdapter<string>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private snackbar: SnackbarService) {
    this._adapter.setLocale('fr');
    this.remplissageChampsFormulaire(data);
    
    this.voitureService.getAll().subscribe(value => {
      this.voitures = value as Voiture[];
      this.filteredMarques = of(this.voitures.map(voiture => voiture.marque.toString()));
      this.filteredAnnees = of(this.voitures.map(voiture => voiture.annee.toString()));
      this.filteredModeles = of(this.voitures.map(voiture => voiture.modele.toString()));
      this.filteredFinitions = of(this.voitures.map(voiture => voiture.finition.toString()));
    });
  }

  onSubmit() {
    let voiture = new Voiture();
    voiture.id = 0;
    voiture.marque = this.formVoiture.value.controlMarque!;
    voiture.annee = parseInt(this.formVoiture.value.controlAnnee!);
    voiture.modele = this.formVoiture.value.controlModele!;
    voiture.finition = this.formVoiture.value.controlFinition!;
    this.voitureService.exist(voiture.marque,
      voiture.annee,
      voiture.modele,
      voiture.finition)
      .subscribe({
        next: value => {
          if (value != null) {
            voiture = value as Voiture;
            this.enregistreVoiture(voiture);
          }
          else {
            this.voitureService.create(voiture).subscribe({
              next: value => {
                voiture = value as Voiture;
                this.enregistreVoiture(voiture);
              },
              error: () => {
                console.log("erreur création voiture");
              }
            });
          }
        }
      });
  }

  enregistreVoiture(voiture: Voiture): void {
    this.voitureEnregistre.voitureId = voiture.id;
    this.voitureEnregistre.dateAchat = this.formVoiture.value.controlDateAchat!;
    this.voitureEnregistre.reparations = this.formVoiture.value.controlReparations!;
    this.voitureEnregistre.prixAchat = parseInt(this.formVoiture.value.controlPrixAchat!);
    this.voitureEnregistre.coutReparations = parseInt(this.formVoiture.value.controlCoutReparations!);
    console.log(this.voitureEnregistre);
    this.voitureEnregistreService.update(this.voitureEnregistre).subscribe({
      next: () => {
        window.location.href = '/admin/voitures';
        this.snackbar.green("Voiture mise à jour");
      },
      error: () => {
        this.snackbar.red("Erreur lors de la mise à jour");
      }
    });
  }

  remplissageChampsFormulaire(data: any): void {
    this.voitureEnregistre = data;
    this.voitureService.getById(this.voitureEnregistre.voitureId).subscribe({
      next: value => {
        const voiture = value as Voiture;
        this.formVoiture.setValue({
          controlDateAchat: this.voitureEnregistre.dateAchat,
          controlPrixAchat: this.voitureEnregistre.prixAchat.toString(),
          controlReparations: this.voitureEnregistre.reparations,
          controlCoutReparations: this.voitureEnregistre.coutReparations.toString(),
          controlMarque: voiture.marque,
          controlModele: voiture.modele,
          controlAnnee: voiture.annee.toString(),
          controlFinition: voiture.finition
        });
      },
      error: (error) => {
        console.log("erreur recuperation voiture"+ error);
      }
    });
  }

  delete(): void {
    this.voitureEnregistreService.delete(this.voitureEnregistre.id).subscribe({
      next: () => {
        this.snackbar.green("Voiture supprimée");
        window.location.href = '/admin/voitures';
      },
      error: (error) => {
        console.log(error);
        this.snackbar.red("Erreur lors de la suppression");
      }
    });
  }
}

