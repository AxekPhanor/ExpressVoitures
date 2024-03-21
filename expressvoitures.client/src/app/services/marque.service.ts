import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class MarqueService extends BaseService {
  getAll() {
    return this.http.get(`${this.url}/Marque/GetAll`, { withCredentials: true });
  }
}
