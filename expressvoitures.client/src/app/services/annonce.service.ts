import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Annonce } from '../models/annonce';

@Injectable({
  providedIn: 'root'
})
export class AnnonceService extends BaseService {
  getByIdAvailable(id: number) {
    return this.http.get(`${this.url}/Annonce/GetByIdAvailable?id=${id}`);
  }
  getAllAvailable() {
    return this.http.get(`${this.url}/Annonce/GetAllAvailable`);
  }

  getAll() {
    return this.http.get(`${this.url}/Annonce/GetAll`, { withCredentials: true })
  }

  create(annonce: Annonce) {
    return this.http.post(`${this.url}/Annonce/Create`,
      {
        voitureEnregistreId: annonce.voitureEnregistreId,
        titre: annonce.titre,
        description: annonce.description,
        photos: annonce.photos,
        prixVente: annonce.prixVente
    }, { withCredentials: true });
  }

  update(annonce: Annonce) {
    return this.http.put(`${this.url}/Annonce/Update?id=` + annonce.id,
      {
        id: annonce.id,
        voitureEnregistreId: annonce.voitureEnregistreId,
        titre: annonce.titre,
        description: annonce.description,
        photos: annonce.photos,
        prixVente: annonce.prixVente
    }, { withCredentials: true });
  }

  delete(id: number) {
    console.log(this.url);
    return this.http.delete(`${this.url}/Annonce/DeleteById?id=` + id, { withCredentials: true });
  }

  upload(files: File[], id: number) {
    const formData = new FormData();
    for (let i = 0; i < files.length; i++) {
      formData.append('files', files[i], files[i].name);
    }
    return this.http.post(`${this.url}/Annonce/UploadImg?id=` + id, formData, { withCredentials: true });
  }

  vendu(id: number) {
    return this.http.get(`${this.url}/Annonce/Sold?id=` + id, { withCredentials: true });
  }
}
