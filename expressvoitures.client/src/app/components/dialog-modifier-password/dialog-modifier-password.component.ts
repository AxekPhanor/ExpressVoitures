import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { SnackbarService } from '../../services/snackbar.service';

@Component({
  selector: 'app-dialog-modifier-password',
  templateUrl: './dialog-modifier-password.component.html',
  styleUrl: './dialog-modifier-password.component.css'
})
export class DialogModifierPasswordComponent {
  constructor(private authService: AuthService, private snackbar: SnackbarService) { }
  Submit() {
    this.authService.resetPassword().subscribe({
      next: () => {
        this.snackbar.green('Un email pour changer votre mot de passe a été envoyé');
      },
      error: () => {
        this.snackbar.red('Erreur lors de l\'envoi de l\'email');
      }
    });
  }
}
