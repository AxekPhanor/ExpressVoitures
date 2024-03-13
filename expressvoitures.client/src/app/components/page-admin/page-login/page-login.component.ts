import { Component } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

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
    private router: Router
    ) { }

  ngOnInit() {
    this.authService.isLoggedIn().subscribe({
      next: (value) => {
        if (value) {
          this.router.navigate(['/admin/voiture']);
        }
      }
    });
  }

  onSubmit() {
    const username = this.formLogin.value.controlIdentifiant!;
    const password = this.formLogin.value.controlPassword!;
    this.authService.login(username, password).subscribe({
      next: () => {
        window.location.href = '/admin/voitures';
      },
      error: (error) => {
        console.log("error");
        console.log(error);
      }
    });
  }
}
