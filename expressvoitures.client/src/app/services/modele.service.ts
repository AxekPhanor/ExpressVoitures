import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ModeleService extends BaseService {
  getAll() {
    return this.http.get(`${this.url}/Modele/GetAll`, { withCredentials: true });
  }
}
