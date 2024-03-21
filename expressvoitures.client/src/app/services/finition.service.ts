import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class FinitionService extends BaseService {
  getAll() {
    return this.http.get(`${this.url}/Finition/GetAll`, { withCredentials: true });
  }
}
