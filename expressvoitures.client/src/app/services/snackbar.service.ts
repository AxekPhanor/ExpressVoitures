import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {
  constructor(private _snackBar: MatSnackBar) { }
  green(message: string) {
    this._snackBar.open(message, "", {
      duration: 3000,
      panelClass: ['green-snackbar']
    });
  }
  red(message: string) {
    this._snackBar.open(message, "", {
      duration: 3000,
      panelClass: ['red-snackbar']
    });
  }
}
