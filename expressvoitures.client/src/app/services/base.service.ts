import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class BaseService {
  url: string;
  constructor(protected http: HttpClient) {
    this.url = 'http://localhost:5148/api';
  }
}
