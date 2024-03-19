import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { User } from '../models/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {
  override url = 'https://localhost:7182/api/Account';

  login(username: string, password: string): Observable<User> {
    return this.http.post<User>(`${this.url}/Login`, { UserName: username, password: password }, { withCredentials: true });
  }

  logout(): Observable<unknown> {
    return this.http.get(`${this.url}/Logout`, { withCredentials: true });
  }

  isLoggedIn(): Observable<boolean> {
    return this.http.get<boolean>(`${this.url}/IsLoggedIn`, { withCredentials: true });
  }
}
