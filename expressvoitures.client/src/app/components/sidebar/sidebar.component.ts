import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DialogModifierPasswordComponent } from '../dialog-modifier-password/dialog-modifier-password.component';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent {
  constructor(private dialog: MatDialog) {
  }
  openDialog() {
    this.dialog.open(DialogModifierPasswordComponent,
      {
        autoFocus: false,
        disableClose: true
      });
  }
}
