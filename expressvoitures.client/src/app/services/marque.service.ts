import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class MarqueService extends BaseService {
  override url = 'https://localhost:7182/api/Marque';

  getAll() {
    return this.http.get(`${this.url}/GetAll`, { withCredentials: true });
  }
}
