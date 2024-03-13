import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { VoitureService } from '../../services/voiture.service';
import { Voiture } from '../../models/voiture';
import { VoitureEnregistreService } from '../../services/voiture-enregistre.service';
import { VoitureEnregistre } from '../../models/voitureEnregistre';
import { DateAdapter } from '@angular/material/core';
import { MarqueService } from '../../services/marque.service';
import { AnneeService } from '../../services/annee.service';
import { ModeleService } from '../../services/modele.service';
import { FinitionService } from '../../services/finition.service';
import { Marque } from '../../models/marque';
import { Annee } from '../../models/annee';
import { Modele } from '../../models/modele';
import { Finition } from '../../models/finition';

@Component({
  selector: 'app-form-voiture-create',
  templateUrl: './form-voiture-create.component.html',
  styleUrl: './form-voiture.component.css'
})
export class FormVoitureCreateComponent {
  formVoiture = new FormGroup({
    controlMarque: new FormControl(''),
    controlModele: new FormControl(''),
    controlAnnee: new FormControl(''),
    controlFinition: new FormControl(''),
    controlDateAchat: new FormControl(''),
    controlPrixAchat: new FormControl(''),
    controlReparations: new FormControl(''),
    controlCoutReparations: new FormControl('')
  });

  voitures: Voiture[] = [];
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
    private _adapter: DateAdapter<string>)
  {
    this.getMarques();
    this.getAnnees();
    this.getModeles();
    this.getFinition();
    this._adapter.setLocale('fr');
    this.voitureService.getAll().subscribe(value => {
      this.voitures = value as Voiture[];
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
            console.log("voiture existe");
            this.enregistreVoiture(voiture);
          }
          else {
            console.log("voiture n'existe pas");
            this.voitureService.create(voiture).subscribe({
              next: value => {
                voiture = value as Voiture;
                console.log("voiture créée");
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
    voitureEnregistre.dateAchat = this.formVoiture.value.controlDateAchat!;
    voitureEnregistre.reparations = this.formVoiture.value.controlReparations!;
    voitureEnregistre.prixAchat = parseFloat(this.formVoiture.value.controlPrixAchat!);
    voitureEnregistre.coutReparations = parseFloat(this.formVoiture.value.controlCoutReparations!);
    console.log(voitureEnregistre);
    this.voitureEnregistreService.create(voitureEnregistre).subscribe({
      next: () => {
        console.log("voiture enregistrée");
        window.location.href = '/admin/voitures';
      },
      error: () => {
        console.log("erreur création voiture enregistrée");
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
