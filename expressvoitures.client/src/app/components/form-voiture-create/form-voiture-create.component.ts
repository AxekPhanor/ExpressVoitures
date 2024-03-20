import { Component } from '@angular/core';
import { VoitureService } from '../../services/voiture.service';
import { Voiture } from '../../models/voiture';
import { VoitureEnregistreService } from '../../services/voiture-enregistre.service';
import { VoitureEnregistre } from '../../models/voitureEnregistre';
import { MarqueService } from '../../services/marque.service';
import { AnneeService } from '../../services/annee.service';
import { ModeleService } from '../../services/modele.service';
import { FinitionService } from '../../services/finition.service';
import { Marque } from '../../models/marque';
import { Annee } from '../../models/annee';
import { Modele } from '../../models/modele';
import { Finition } from '../../models/finition';
import { SnackbarService } from '../../services/snackbar.service';
import { FormHelper } from '../../helpers/formHelper';

@Component({
  selector: 'app-form-voiture-create',
  templateUrl: './form-voiture-create.component.html',
  styleUrl: './form.component.css'
})
export class FormVoitureCreateComponent {
  form = new FormHelper();
  formVoiture = this.form.createFormVoiture();

  marques: string[] = [];
  annees: string[] = [];
  modeles: string[] = [];
  finitions: string[] = [];

  constructor(private marqueService: MarqueService,
    private anneeService: AnneeService,
    private modeleService: ModeleService,
    private finitionService: FinitionService,
    private voitureService: VoitureService,
    private voitureEnregistreService: VoitureEnregistreService,
    private snackbar: SnackbarService)
  {
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

  enregistreVoiture(voiture: Voiture) {
    const voitureEnregistre = new VoitureEnregistre();
    voitureEnregistre.voitureId = voiture.id;
    const dateAchat = new Date(this.formVoiture.value.controlDateAchat!);
    dateAchat.setMinutes(dateAchat.getMinutes() - dateAchat.getTimezoneOffset());
    voitureEnregistre.dateAchat = dateAchat.toISOString();
    voitureEnregistre.prixAchat = parseFloat(this.formVoiture.value.controlPrixAchat!);
    if (this.formVoiture.value.controlReparations == "") {
      voitureEnregistre.reparations = "Aucune";
    }
    else {
      voitureEnregistre.reparations = this.formVoiture.value.controlReparations!;
    }
    if (this.formVoiture.value.controlCoutReparations == "") {
      voitureEnregistre.coutReparations = 0;
    }
    else {
      voitureEnregistre.coutReparations = parseFloat(this.formVoiture.value.controlCoutReparations!);
    }
    this.voitureEnregistreService.create(voitureEnregistre).subscribe({
      next: () => {
        this.snackbar.green("Voiture enregistrée");
        window.location.href = '/admin/voitures';
      },
      error: () => {
        this.snackbar.red("Erreur lors de l'enregistrement");
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
