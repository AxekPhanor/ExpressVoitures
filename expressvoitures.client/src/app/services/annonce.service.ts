import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class AnnonceService extends BaseService {
  override url = 'https://localhost:7182/api/Annonce';

  getById(id: number) {
    return this.http.get(`${this.url}/GetById/${id}`);
  }
  getAll() {
    return this.http.get(`${this.url}/GetAllAvailable`);
  }
}
