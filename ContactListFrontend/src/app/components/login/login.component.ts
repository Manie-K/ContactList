import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {Subscription} from 'rxjs';
import {AuthService} from '../../services/auth/auth.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [
    FormsModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent{
  email: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  login():void  {
    const loginData = {email: this.email, password: this.password};
    this.authService.login(loginData).subscribe();
    this.router.navigate(['/contacts']);
  }
}
