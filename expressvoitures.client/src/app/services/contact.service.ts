import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Mail } from '../models/mail';

@Injectable({
  providedIn: 'root'
})
export class ContactService extends BaseService {
  Send(mail: Mail) {
    return this.http.post(`${this.url}/Contact/Send`, mail);
  }
}
