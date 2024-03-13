import { Component } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'page-logout',
  templateUrl: './page-logout.component.html',
  styleUrl: './page-logout.component.css'
})
export class PageLogoutComponent {
  constructor(
    private authService: AuthService,
    private router: Router) { }

  ngOnInit() {
    this.authService.logout().subscribe({
      next: () => {
        window.location.href = '/';
      },
      error: (error) => {
        console.log(error.status);
      }
    });
  }
}
