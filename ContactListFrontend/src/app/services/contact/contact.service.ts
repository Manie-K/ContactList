import { Injectable } from '@angular/core';
// @ts-ignore
import {BasicContactDTO} from '../../models/contact/BasicContactDTO';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../../environments/environment.development';
import {Observable, tap} from 'rxjs';
// @ts-ignore
import {DetailContactDTO} from '../../models/contact/DetailContactDTO';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http: HttpClient) { }

  getAllContacts(): Observable<BasicContactDTO[]> {
    const url: string = `${environment.apiUrl}/contacts`;
    return this.http.get<BasicContactDTO[]>(url);
  }

  getContactById(id: number): Observable<DetailContactDTO>{
    const url: string = `${environment.apiUrl}/contacts/${id}`;
    return this.http.get<DetailContactDTO>(url);
  }
}
