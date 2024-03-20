import { Component } from '@angular/core';
import { FormHelper } from '../../helpers/formHelper';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { NewPassword } from '../../models/newPassword';
import { SnackbarService } from '../../services/snackbar.service';

@Component({
  selector: 'app-form-new-password',
  templateUrl: './form-new-password.component.html',
  styleUrl: './form-new-password.component.css'
})
export class FormNewPasswordComponent {
  form = new FormHelper();
  formNewPassword = this.form.createformNewPassword();
  code = "";
  constructor(private route: ActivatedRoute,
    private authService: AuthService,
    private snackbar: SnackbarService) {
    this.code = this.route.snapshot.queryParamMap.get('code')!;
  }

  onSubmit() {
    if (this.formNewPassword.value.controlNewPassword! == this.formNewPassword.value.controlNewPasswordConfirm!) {
      const newPassword = new NewPassword();
      newPassword.value = this.formNewPassword.value.controlNewPassword!;
      newPassword.code = encodeURIComponent(this.code);
      this.authService.setNewPassword(newPassword).subscribe({
        next: () => {
          this.snackbar.green('Mot de passe modifié');
          window.location.href = '/admin/voitures';
        },
        error: errors => {
          for (const error of errors.error) {
            this.snackbar.red(error.description);
          }
        }
      });
    }
    else {
      this.snackbar.red('Les mots de passe ne correspondent pas');
    }
  }
}
