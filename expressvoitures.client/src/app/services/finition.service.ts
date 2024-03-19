import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class FinitionService extends BaseService {
  override url = 'https://localhost:7182/api/Finition';

  getAll() {
    return this.http.get(`${this.url}/GetAll`, { withCredentials: true });
  }
}
