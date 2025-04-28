import { Routes } from '@angular/router';
import {LoginComponent} from './components/login/login.component';
import {ContactlistComponent} from './components/contactlist/contactlist.component';
import {ContactdetailComponent} from './components/contactdetail/contactdetail.component';

export const routes: Routes = [
  {path: '', component: ContactlistComponent},
  { path: 'login', component: LoginComponent },
  { path: 'register', component: LoginComponent },
  { path: 'contacts', component: ContactlistComponent },
  { path: 'contacts/:id', component: ContactdetailComponent },
];
