import { Component } from '@angular/core';
import { Mail } from '../../models/mail';
import { SnackbarService } from '../../services/snackbar.service';
import { ContactService } from '../../services/contact.service';
import { FormHelper } from '../../helpers/formHelper';

@Component({
  selector: 'page-contact',
  templateUrl: './page-contact.component.html',
  styleUrl: './page-contact.component.css'
})
export class PageContactComponent {
  form = new FormHelper();
  formContact = this.form.createFormContact();
  mail = new Mail();

  constructor(private contactService: ContactService, private snackbar: SnackbarService) {
  }

  onSubmit() {
    this.mail.FromName = this.formContact.value.controlName!;
    this.mail.FromEmail = this.formContact.value.controlEmail!;
    this.mail.Subject = 'Contact';
    this.mail.Body = this.formContact.value.controlMessage!.replaceAll('\n', '<br>');
    this.send();
  }

  send() {
    this.contactService.Send(this.mail).subscribe({
      next: () => {
        this.snackbar.green('Votre email à été envoyé');
      },
      error: () => {
        this.snackbar.red('Erreur lors de l\'envoi de l\'mail');
      }
    });
  }
}
