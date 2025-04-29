import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {BasicContactDTO} from '../../models/contact/BasicContactDTO';
import {environment} from '../../../environments/environment.development';
import {GetCategoryDTO} from '../../models/category/GetCategoryDTO';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  getAllCategories(): Observable<GetCategoryDTO[]> {
    const url: string = `${environment.apiUrl}/categories`;
    const headers = new HttpHeaders({ 'Authorization': 'Bearer ' + sessionStorage.getItem('token') });
    return this.http.get<GetCategoryDTO[]>(url, {headers});
  }

  getCategoryByName(name: string): GetCategoryDTO|undefined {
    let cat: GetCategoryDTO | undefined;
    this.getAllCategories().subscribe(categories => {
      const category = categories.find(category => category.name === name);
      if (category) {
        cat = category;
      } else {
        throw new Error('Category not found');
      }
    })
    return cat;
  }
}
