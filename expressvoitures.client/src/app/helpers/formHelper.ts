/* eslint-disable @typescript-eslint/no-explicit-any */
import { AbstractControl, FormControl, FormGroup, ValidatorFn, Validators } from "@angular/forms";

export class FormHelper {
  createformNewPassword() {
    const formNewPassword = new FormGroup({
      controlNewPassword: new FormControl('', Validators.compose([
        Validators.required,
      ])),
      controlNewPasswordConfirm: new FormControl('', Validators.compose([
        Validators.required,
      ]))
    });
    return formNewPassword;
  }

  createFormVoiture(): FormGroup {
    const formVoiture = new FormGroup({
      controlMarque: new FormControl('', Validators.compose([
        Validators.pattern('^[a-zA-Z0-9\n àâäéèêëïîôöùûüçÀÂÄÉÈÊËÏÎÔÖÙÛÜÇ.,;:!?]*$'),
        Validators.required,
      ])),
      controlModele: new FormControl('', Validators.compose([
        Validators.pattern('^[a-zA-Z0-9\n àâäéèêëïîôöùûüçÀÂÄÉÈÊËÏÎÔÖÙÛÜÇ.,;:!?]*$'),
        Validators.required,
      ])),
      controlAnnee: new FormControl('', Validators.compose([
        Validators.min(1990),
        Validators.max(new Date().getFullYear()),
        Validators.required,
      ])),
      controlFinition: new FormControl('', Validators.compose([
        Validators.pattern('^[a-zA-Z0-9\n àâäéèêëïîôöùûüçÀÂÄÉÈÊËÏÎÔÖÙÛÜÇ.,;:!?]*$'),
        Validators.required,
      ])),
      controlDateAchat: new FormControl('', Validators.compose([
        this.dateGreaterThanYear('controlAnnee'),
        Validators.required,
      ])),
      controlPrixAchat: new FormControl('', Validators.compose([
        Validators.pattern('^[0-9]*$'),
        Validators.required,
      ])),
      controlReparations: new FormControl('', Validators.compose([
        Validators.pattern('^[a-zA-Z0-9\n àâäéèêëïîôöùûüçÀÂÄÉÈÊËÏÎÔÖÙÛÜÇ.,;:!?]*$')
      ])),
      controlCoutReparations: new FormControl('', Validators.compose([
        Validators.pattern('^[0-9]*$'),
      ])),
    });
    return formVoiture;
  }

  createFormAnnonce(): FormGroup {
    const formAnnonce = new FormGroup({
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
    return formAnnonce;
  }

  createFormContact(): FormGroup {
    const formContact = new FormGroup({
      controlNom: new FormControl('', Validators.compose([
        Validators.required,
      ])),
      controlEmail: new FormControl('', Validators.compose([
        Validators.email,
        Validators.required,
      ])),
      controlMessage: new FormControl('', Validators.compose([
        Validators.pattern('^[a-zA-Z0-9\n àâäéèêëïîôöùûüçÀÂÄÉÈÊËÏÎÔÖÙÛÜÇ.,;:!?]*$'),
        Validators.required,
      ]))
    });
    return formContact;
  }

  private dateGreaterThanYear(yearControlName: string): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      const yearControl = control.parent?.get(yearControlName);
      if (yearControl && control.value) {
        const year = new Date(yearControl.value).getFullYear();
        const date = new Date(control.value).getFullYear();
        return date > year ? null : { 'dateGreaterThanYear': { value: control.value } };
      }
      return null;
    };
  }
}
