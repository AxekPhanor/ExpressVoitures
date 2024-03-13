/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-description',
  templateUrl: './dialog-description.component.html',
  styleUrl: './dialog-description.component.css'
})
export class DialogDescriptionComponent {
  description = '';
  constructor(@Inject(MAT_DIALOG_DATA) private data: any) {
    this.description = data.description;
  }
}
