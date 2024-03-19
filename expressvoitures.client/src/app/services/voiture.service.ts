import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Voiture } from '../models/voiture';

@Injectable({
  providedIn: 'root'
})
export class VoitureService extends BaseService {
  override url = 'https://localhost:7182/api/Voiture';

  create(voiture: Voiture) {
    return this.http.post(`${this.url}/Create`, voiture, { withCredentials: true })
  }

  getAll() {
    return this.http.get(`${this.url}/GetAll`, { withCredentials: true });
  }

  exist(marque: string, annee: number, modele: string, finition: string) {
    return this.http.post(`${this.url}/Exist`,
      {
        marque: marque,
        annee: annee,
        modele: modele,
        finition: finition
      },
      { withCredentials: true });
  }

  getById(id: number) {
    return this.http.get(`${this.url}/GetById?id=${id}`, { withCredentials: true });
  }
}
