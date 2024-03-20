/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject } from '@angular/core';
import { VoitureService } from '../../services/voiture.service';
import { Voiture } from '../../models/voiture';
import { VoitureEnregistreService } from '../../services/voiture-enregistre.service';
import { VoitureEnregistre } from '../../models/voitureEnregistre';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SnackbarService } from '../../services/snackbar.service';
import { FormHelper } from '../../helpers/formHelper';
import { MarqueService } from '../../services/marque.service';
import { AnneeService } from '../../services/annee.service';
import { ModeleService } from '../../services/modele.service';
import { FinitionService } from '../../services/finition.service';
import { Annee } from '../../models/annee';
import { Marque } from '../../models/marque';
import { Modele } from '../../models/modele';
import { Finition } from '../../models/finition';

@Component({
  selector: 'app-form-voiture-maj',
  templateUrl: './form-voiture-maj.component.html',
  styleUrl: './form.component.css'
})
export class FormVoitureMajComponent {
  form = new FormHelper();
  formVoiture = this.form.createFormVoiture();

  marques: string[] = [];
  annees: string[] = [];
  modeles: string[] = [];
  finitions: string[] = [];
  voitureEnregistre = new VoitureEnregistre();

  constructor(private voitureService: VoitureService,
    private voitureEnregistreService: VoitureEnregistreService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private snackbar: SnackbarService,
    private marqueService: MarqueService,
    private anneeService: AnneeService,
    private modeleService: ModeleService,
    private finitionService: FinitionService)
  {
    this.remplissageChampsFormulaire(data);
    this.getMarques();
    this.getAnnees();
    this.getModeles();
    this.getFinition();
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
    this.voitureEnregistre.voiture = `${voiture.marque} ${voiture.annee} ${voiture.modele} ${voiture.finition}` ;
    const dateAchat = new Date(this.formVoiture.value.controlDateAchat!);
    dateAchat.setMinutes(dateAchat.getMinutes() - dateAchat.getTimezoneOffset());
    this.voitureEnregistre.dateAchat = dateAchat.toISOString();
    this.voitureEnregistre.reparations = this.formVoiture.value.controlReparations!;
    this.voitureEnregistre.prixAchat = parseInt(this.formVoiture.value.controlPrixAchat!);
    this.voitureEnregistre.coutReparations = parseInt(this.formVoiture.value.controlCoutReparations!);
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
        console.log("erreur recuperation voiture" + error);
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

  getMarques() {
    this.marqueService.getAll().subscribe({
      next: value => {
        console.log(value);
        const marques = value as Marque[];
        for (let i = 0; i < marques.length; i++) {
          this.marques.push(marques[i].nom);
        }
      }
    });
  }

  getAnnees() {
    this.anneeService.getAll().subscribe({
      next: value => {
        const annees = value as Annee[];
        for (let i = 0; i < annees.length; i++) {
          this.annees.push(annees[i].valeur.toString());
        }
      }
    });
  }

  getModeles() {
    this.modeleService.getAll().subscribe({
      next: value => {
        const modeles = value as Modele[];
        for (let i = 0; i < modeles.length; i++) {
          this.modeles.push(modeles[i].nom.toString());
        }
      }
    });
  }

  getFinition() {
    this.finitionService.getAll().subscribe({
      next: value => {
        const finitions = value as Finition[];
        for (let i = 0; i < finitions.length; i++) {
          this.finitions.push(finitions[i].nom.toString());
        }
      }
    });
  }
}
