import { Component } from '@angular/core';
import { MailService } from '../../services/mail.service';
import { Mail } from '../../models/mail';
import { SnackbarService } from '../../services/snackbar.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'page-contact',
  templateUrl: './page-contact.component.html',
  styleUrl: './page-contact.component.css'
})
export class PageContactComponent {
  formContact = new FormGroup({
    controlNom: new FormControl('', Validators.compose([
      Validators.required,
    ])),
    controlEmail: new FormControl('', Validators.compose([
      Validators.required,
    ])),
    controlMessage: new FormControl('', Validators.compose([
      Validators.pattern('^[a-zA-Z0-9\n]*$'),
      Validators.required,
    ]))
  });
  mail = new Mail();

  constructor(private mailService: MailService, private snackbar: SnackbarService) {
  }

  onSubmit() {
    this.mail.FromName = this.formContact.controls.controlNom.value!;
    this.mail.FromEmail = this.formContact.controls.controlEmail.value!;
    this.mail.Subject = 'Contact';
    this.mail.Body = this.formContact.controls.controlMessage.value!.replaceAll('\n', '<br>');
    this.send();
  }

  send() {
    this.mailService.Send(this.mail).subscribe({
      next: () => {
        this.snackbar.green('Votre email à été envoyé');
      },
      error: () => {
        this.snackbar.red('Erreur lors de l\'envoi du mail');
      }
    });
  }
}
