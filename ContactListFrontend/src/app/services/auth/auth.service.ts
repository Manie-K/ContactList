import {EventEmitter, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable, tap} from 'rxjs';
import {AuthResponseDTO} from '../../models/auth/AuthResponseDTO';
import {environment} from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  loginChanged = new EventEmitter<void>();
  constructor(private http: HttpClient) { }

  isLoggedIn(): boolean {
    return !!sessionStorage.getItem('token');
  }

  getUsername(): string {
    return sessionStorage.getItem('username') || '';
  }
  login(credentials: {email: string, password: string}):Observable<any> {
    const url: string = `${environment.apiUrl}/auth/login`;

    return this.http.post<AuthResponseDTO>(url, credentials).pipe(
      tap(response  => {
        console.log(response);
        if (response?.token) {
          sessionStorage.setItem('token', response.token);
        }
        if(response?.name) {
          sessionStorage.setItem('username', response.name);
        }
        this.loginChanged.emit();
      })
    )
  }

  register(credentials: {name: string, email: string, password: string}):Observable<any> {
    const url: string = `${environment.apiUrl}/auth/register`;

    return this.http.post<AuthResponseDTO>(url, credentials).pipe(
      tap(response  => {
        console.log(response);
        if (response?.token) {
          sessionStorage.setItem('token', response.token);
        }
        if(response?.name) {
          sessionStorage.setItem('username', response.name);
        }
        this.loginChanged.emit();
      })
    )
  }

  logout(): void {
    sessionStorage.removeItem('token');
    sessionStorage.removeItem('username');
    this.loginChanged.emit();
  }

}
