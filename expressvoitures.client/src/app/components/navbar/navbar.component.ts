import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  isLoggedIn = false;
  montrerOverlay = false;

  constructor(
    private authService: AuthService) { }

  ngOnInit() {
    this.authService.isLoggedIn().subscribe({
      next: (value) => {
        console.log(value);
        this.isLoggedIn = value;
      }
    });
  }
}
