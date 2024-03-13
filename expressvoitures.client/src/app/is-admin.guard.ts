import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from './services/auth.service';
import { catchError, map } from 'rxjs/operators';
import { of } from 'rxjs';

export const isAdminGuard: CanActivateFn = () => {
  const authService = inject(AuthService);
  const router = inject(Router);
  return authService.isLoggedIn().pipe(
    map((value) => {
      if (!value) {
        router.navigate(['/notfound']);
      }
      return value;
    }),
    catchError((error) => {
      console.log(error);
      return of(false);
    })
  );
};

