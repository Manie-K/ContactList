import { Routes } from '@angular/router';
import {LoginComponent} from './components/login/login.component';
import {ContactlistComponent} from './components/contactlist/contactlist.component';
import {ContactdetailComponent} from './components/contactdetail/contactdetail.component';
import {RegisterComponent} from './components/register/register.component';

export const routes: Routes = [
  {path: '', component: ContactlistComponent},
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'contacts', component: ContactlistComponent },
  { path: 'contacts/:id', component: ContactdetailComponent },
];
