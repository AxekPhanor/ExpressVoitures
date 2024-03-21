import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class AnneeService extends BaseService {
  getAll() {
    return this.http.get(`${this.url}/Annee/GetAll`, { withCredentials: true });
  }
}
