import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Mail } from '../models/mail';

@Injectable({
  providedIn: 'root'
})
export class MailService extends BaseService {
  override url = 'https://localhost:44383/api/Mail';
  Send(mail: Mail) {
    return this.http.post(`${this.url}/Send`, mail);
  }
}
