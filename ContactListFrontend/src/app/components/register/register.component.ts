import { Component } from '@angular/core';
import {AuthService} from '../../services/auth/auth.service';
import {Router} from '@angular/router';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

@Component({
  selector: 'app-register',
  imports: [
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  name: string = '';
  email: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  register():void  {
    const registerData = {name: this.name, email: this.email, password: this.password};
    this.authService.register(registerData).subscribe((response) => {
        console.log('Register successful');
        this.router.navigate(['/contacts']);
      },
      (error) => {
        console.error('Register failed', error);
        alert('Register failed. Please check your credentials.');
      });
  }
}
