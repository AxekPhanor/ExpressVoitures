import { Component } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { SnackbarService } from '../../../services/snackbar.service';

@Component({
  selector: 'page-login',
  templateUrl: './page-login.component.html',
  styleUrl: './page-login.component.css'
})
export class PageLoginComponent {
  formLogin = new FormGroup({
    controlIdentifiant: new FormControl(''),
    controlPassword: new FormControl(''),
  });

  constructor(
    private authService: AuthService,
    private router: Router,
    private snackbar: SnackbarService) { }

  ngOnInit() {
    this.authService.isLoggedIn().subscribe({
      next: (value) => {
        if (value) {
          this.router.navigate(['/admin/voitures']);
        }
      }
    });
  }

  onSubmit() {
    const username = this.formLogin.value.controlIdentifiant!;
    const password = this.formLogin.value.controlPassword!;
    this.authService.login(username, password).subscribe({
      next: () => {
        this.router.navigate(['/admin/voitures']);
      },
      error: (error) => {
        this.snackbar.red("Identifiant ou mot de passe incorrect");
        console.log(error);
      }
    });
  }
}
