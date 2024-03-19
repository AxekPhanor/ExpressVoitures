import { Injectable } from '@angular/core';
import { VoitureEnregistre } from '../models/voitureEnregistre';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class VoitureEnregistreService extends BaseService {
  override url = 'https://localhost:7182/api/VoitureEnregistre';

  getById(id: number) {
    return this.http.get(`${this.url}/GetById?id=${id}`, { withCredentials: true });
  }

  create(voitureEnregistre: VoitureEnregistre) {
    return this.http.post(`${this.url}/Create`, voitureEnregistre, { withCredentials: true })
  }
  getAll() {
    return this.http.get(`${this.url}/GetAll`, { withCredentials: true });
  }
  update(voitureEnregistre: VoitureEnregistre) {
    return this.http.put(`${this.url}/Update?id=` + voitureEnregistre.id,
    {
      voitureId: voitureEnregistre.voitureId,
      dateAchat: voitureEnregistre.dateAchat,
      prixAchat: voitureEnregistre.prixAchat,
      reparations: voitureEnregistre.reparations,
      coutReparations: voitureEnregistre.coutReparations
    }, { withCredentials: true });
  }
  delete(id: number) {
    return this.http.delete(`${this.url}/DeleteById?id=${id}`, { withCredentials: true });
  }
}
