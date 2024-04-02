/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Annonce } from '../../models/annonce';
import { AnnonceService } from '../../services/annonce.service';
import { SnackbarService } from '../../services/snackbar.service';
import { FormHelper } from '../../helpers/formHelper';

@Component({
  selector: 'app-form-annonce-create',
  templateUrl: './form-annonce-create.component.html',
  styleUrl: './form.component.css'
})

export class FormAnnonceCreateComponent {
  form = new FormHelper();
  formAnnonce = this.form.createFormAnnonce();

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
    this.annonce.description = this.formAnnonce.value.controlDescription!.replaceAll('\n', '<br>');
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
