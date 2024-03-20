import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Mail } from '../models/mail';

@Injectable({
  providedIn: 'root'
})
export class ContactService extends BaseService {
  override url = 'https://localhost:7182/api/Contact';
  Send(mail: Mail) {
    return this.http.post(`${this.url}/Send`, mail);
  }
}
