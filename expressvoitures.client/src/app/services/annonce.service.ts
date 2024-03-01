import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class AnnonceService extends BaseService {
  override url = 'https://localhost:7182/api/Annonce';

  getByIdAvailable(id: number) {
    return this.http.get(`${this.url}/GetByIdAvailable/?id=${id}`);
  }
  getAllAvailable() {
    return this.http.get(`${this.url}/GetAllAvailable`);
  }
}
