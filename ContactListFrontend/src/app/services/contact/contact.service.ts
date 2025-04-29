import { Injectable } from '@angular/core';
// @ts-ignore
import {BasicContactDTO} from '../../models/contact/BasicContactDTO';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {environment} from '../../../environments/environment.development';
import {Observable, tap} from 'rxjs';
// @ts-ignore
import {DetailContactDTO} from '../../models/contact/DetailContactDTO';
import {CreateContactDTO} from '../../models/contact/CreateContactDTO';
import {UpdateContactDTO} from '../../models/contact/UpdateContactDTO';

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

  deleteContact(id: number): Observable<void> {
    const url: string = `${environment.apiUrl}/contacts/${id}`;
    const headers = new HttpHeaders({ 'Authorization': 'Bearer ' + sessionStorage.getItem('token') });
    return this.http.delete<void>(url, {headers} );
  }

  createContact(contact: CreateContactDTO) : Observable<DetailContactDTO>
  {
    const url: string = `${environment.apiUrl}/contacts`;
    const headers = new HttpHeaders({ 'Authorization': 'Bearer ' + sessionStorage.getItem('token') });
    return this.http.post<DetailContactDTO>(url, contact, {headers});
  }

  updateContact(id: number, contact: UpdateContactDTO) : Observable<DetailContactDTO>
  {
    const url: string = `${environment.apiUrl}/contacts/${id}`;
    const headers = new HttpHeaders({ 'Authorization': 'Bearer ' + sessionStorage.getItem('token') });
    return this.http.put<DetailContactDTO>(url, contact, {headers});
  }
}
