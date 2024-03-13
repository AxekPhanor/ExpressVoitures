/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Annonce } from '../../models/annonce';
import { AnnonceService } from '../../services/annonce.service';

@Component({
  selector: 'app-form-annonce-create',
  templateUrl: './form-annonce-create.component.html',
  styleUrl: './form-voiture.component.css'
})
export class FormAnnonceCreateComponent {
  formAnnonce = new FormGroup({
    controlTitre: new FormControl(''),
    controlDescription: new FormControl(''),
    controlPrixVente: new FormControl('')
  });

  annonce: Annonce = new Annonce();
  files: File[] = [];

  constructor(private annonceService: AnnonceService,
    @Inject(MAT_DIALOG_DATA) private data: any) {
    console.log(data);
    this.formAnnonce.setValue({
        controlTitre: this.data.voitureEnregistre.voiture,
        controlDescription: "",
        controlPrixVente: ""
    });
  }

  onChange(event: any) {
    const files = event.target.files;
    if (files.length) {
      this.files = files;
      for (let i = 0; i < files.length; i++) {
        this.annonce.photos[i] = this.data.voitureEnregistre.id + '-' +
          this.data.voitureEnregistre.voiture.replaceAll(' ', '_') + '(' + i + ')' +'.jpg';
        console.log(this.annonce.photos[i]);
      }
    }
  }

  onSubmit() {
    this.annonce.voitureEnregistreId = this.data.voitureEnregistre.id;
    this.annonce.titre = this.formAnnonce.value.controlTitre!;
    this.annonce.description = this.formAnnonce.value.controlDescription!;
    this.annonce.prixVente = parseFloat(this.formAnnonce.value.controlPrixVente!);
    this.create();
    this.upload(this.files);
  }

  create() {
    this.annonceService.create(this.annonce).subscribe({
      next: () => {
        console.log("annonce créée");
      },
      error: error => {
        console.log("Erreur lors de la création" + error);
      }
    });
  }

  upload(files: File[]) {
    this.annonceService.upload(files, this.data.voitureEnregistre.id).subscribe({
      next: () => {
        console.log("image uploadée");
      },
      error: error => {
        console.log("Erreur lors de l'upload" + error);
      }
    });
  }
}
