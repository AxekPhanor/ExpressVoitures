/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Annonce } from '../../models/annonce';
import { AnnonceService } from '../../services/annonce.service';
import { SnackbarService } from '../../services/snackbar.service';

@Component({
  selector: 'app-form-annonce-create',
  templateUrl: './form-annonce-create.component.html',
  styleUrl: './form-voiture.component.css'
})

export class FormAnnonceCreateComponent {
  formAnnonce = new FormGroup({
    controlTitre: new FormControl('', Validators.compose([
      Validators.required,
    ])),
    controlDescription: new FormControl('', Validators.compose([
      Validators.required,
    ])),
    controlPrixVente: new FormControl('', Validators.compose([
      Validators.pattern('^[0-9]*$'),
      Validators.required,
    ]))
  });

  annonce: Annonce = new Annonce();
  files: File[] = [];

  constructor(private annonceService: AnnonceService,
    @Inject(MAT_DIALOG_DATA) private data: any,
    private snackbar: SnackbarService) {
    this.formAnnonce.setValue({
        controlTitre: this.data.voiture,
        controlDescription: "",
        controlPrixVente: ""
    });
  }

  onChange(event: any) {
    const files = event.target.files;
    if (files.length) {
      this.files = files;
      for (let i = 0; i < files.length; i++) {
        this.annonce.photos[i] = this.data.id + '-' +
          this.data.voiture.replaceAll(' ', '_') + '(' + i + ')' +'.jpg';
      }
    }
  }

  onSubmit() {
    this.annonce.voitureEnregistreId = this.data.id;
    this.annonce.titre = this.formAnnonce.value.controlTitre!;
    this.annonce.description = this.formAnnonce.value.controlDescription!;
    this.annonce.prixVente = parseFloat(this.formAnnonce.value.controlPrixVente!);
    this.create();
    this.upload(this.files);
  }

  create() {
    this.annonceService.create(this.annonce).subscribe({
      next: () => {
        this.snackbar.green("Annonce créée");
      },
      error: error => {
        console.log("Erreur lors de la création" + error);
        this.snackbar.red("Erreur lors de la création");
      }
    });
  }

  upload(files: File[]) {
    this.annonceService.upload(files, this.data.id).subscribe({
      error: error => {
        console.log("Erreur lors de l'upload" + error);
        this.snackbar.red("Erreur lors de l'upload");
      }
    });
  }
}
