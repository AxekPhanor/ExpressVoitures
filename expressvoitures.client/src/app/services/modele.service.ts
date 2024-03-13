import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ModeleService extends BaseService {
  override url = 'https://localhost:44383/api/Modele';

  getAll() {
    return this.http.get(`${this.url}/GetAll`, { withCredentials: true });
  }
}
