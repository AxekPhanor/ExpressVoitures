/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AnnonceService } from '../../services/annonce.service';
import { Annonce } from '../../models/annonce';
import { VoitureEnregistreService } from '../../services/voiture-enregistre.service';
import { VoitureEnregistre } from '../../models/voitureEnregistre';

@Component({
  selector: 'app-form-annonce-maj',
  templateUrl: './form-annonce-maj.component.html',
  styleUrl: './form-annonce-maj.component.css'
})
export class FormAnnonceMajComponent {
  formAnnonce = new FormGroup({
    controlTitre: new FormControl(''),
    controlDescription: new FormControl(''),
    controlPrixVente: new FormControl('')
  });

  annonce: Annonce = new Annonce();
  voitureEnregistre: VoitureEnregistre = new VoitureEnregistre();
  files: File[] = [];

  constructor(private annonceService: AnnonceService,
    private voitureEnregistreService: VoitureEnregistreService,
    @Inject(MAT_DIALOG_DATA) private data: Annonce) {
    console.log(data);
    this.formAnnonce.setValue({
      controlTitre: data.titre,
      controlDescription: data.description,
      controlPrixVente: data.prixVente.toString()
    });
    this.annonce.id = this.data.id;
    this.annonce.voitureEnregistreId = this.data.voitureEnregistreId;
    this.annonce.photos = data.photos;
    this.annonce.titre = data.titre;
    this.annonce.description = data.description;
    this.annonce.prixVente = data.prixVente;
    this.getVoitureEnregistre();
  }

  onChange(event: any) {
    const files = event.target.files;
    if (files.length) {
      this.files = files;
      for (let i = 0; i < files.length; i++) {
        this.annonce.photos.push(this.voitureEnregistre.id + '-' +
        this.voitureEnregistre.voiture.replaceAll(' ', '_') + '(' + this.annonce.photos.length + ')' + '.jpg');
      }
    }
  }

  onSubmit() {
    this.annonce.titre = this.formAnnonce.value.controlTitre!;
    this.annonce.description = this.formAnnonce.value.controlDescription!;
    this.annonce.prixVente = parseFloat(this.formAnnonce.value.controlPrixVente!);
    this.update();
    this.upload(this.files);
  }

  update() {
    this.annonceService.update(this.annonce).subscribe({
      next: () => {
        console.log("annonce modifié");
        window.location.href = '/admin/annonces';
      },
      error: error => {
        console.log("Erreur lors de la création" + error);
      }
    });
  }

  delete() {
    this.annonceService.delete(this.annonce.id).subscribe({
      next: () => {
        console.log("annonce supprimée");
        window.location.href = '/admin/annonces';
      },
      error: error => {
        console.log("Erreur lors de la suppression" + error);
      }
    });
  }

  upload(files: File[]) {
    this.annonceService.upload(files, this.voitureEnregistre.id).subscribe({
      next: () => {
        console.log("image uploadée");
      },
      error: error => {
        console.log("Erreur lors de l'upload" + error);
      }
    });
  }

  getVoitureEnregistre() {
    this.voitureEnregistreService.getById(this.data.voitureEnregistreId).subscribe({
      next: value => {
        this.voitureEnregistre = value as VoitureEnregistre;
      },
      error: error => {
        console.log("Erreur lors de la récupération de la voiture enregistrée" + error);
      }
    });
  }
}
