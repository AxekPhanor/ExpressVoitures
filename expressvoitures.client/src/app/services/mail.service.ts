import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Mail } from '../models/mail';

@Injectable({
  providedIn: 'root'
})
export class ContactService extends BaseService {
  override url = 'https://localhost:7182/api/Contact';
  send(mail: Mail) {
    return this.http.post(`${this.url}/Send`, {
      fromName: mail.fromName,
      fromEmail: mail.fromEmail,
      subject: mail.subject,
      body: mail.body
    });
  }
}
