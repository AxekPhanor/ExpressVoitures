import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { User } from '../models/user';
import { Observable } from 'rxjs';
import { NewPassword } from '../models/newPassword';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {
  override url = 'https://localhost:7182/api/Account';

  login(username: string, password: string): Observable<User> {
    return this.http.post<User>(`${this.url}/Account/Login`, { UserName: username, password: password }, { withCredentials: true });
  }

  logout() {
    return this.http.get(`${this.url}/Account/Logout`, { withCredentials: true });
  }

  isLoggedIn(): Observable<boolean> {
    return this.http.get<boolean>(`${this.url}/Account/IsLoggedIn`, { withCredentials: true });
  }

  resetPassword() {
    return this.http.post(`${this.url}/Account/ResetPassword`, "https://localhost:4200/admin/reset-password", { withCredentials: true })
  }

  setNewPassword(newPassword: NewPassword) {
    return this.http.post(`${this.url}/Account/SetNewPassword`,
      {
        newPassword: newPassword.value,
        code: newPassword.code
      }, { withCredentials: true })
  }
}
