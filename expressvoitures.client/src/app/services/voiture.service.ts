import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Voiture } from '../models/voiture';

@Injectable({
  providedIn: 'root'
})
export class VoitureService extends BaseService {
  create(voiture: Voiture) {
    return this.http.post(`${this.url}/Voiture/Create`, voiture, { withCredentials: true })
  }

  getAll() {
    return this.http.get(`${this.url}/Voiture/GetAll`, { withCredentials: true });
  }

  exist(marque: string, annee: number, modele: string, finition: string) {
    return this.http.post(`${this.url}/Voiture/Exist`,
      {
        marque: marque,
        annee: annee,
        modele: modele,
        finition: finition
      },
      { withCredentials: true });
  }

  getById(id: number) {
    return this.http.get(`${this.url}/Voiture/GetById?id=${id}`, { withCredentials: true });
  }
}
