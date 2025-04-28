import {Component, OnDestroy, OnInit} from '@angular/core';
// @ts-ignore
import {BasicContactDTO} from '../../models/contact/BasicContactDTO';
import {ContactService} from '../../services/contact/contact.service';
import {NgForOf, NgIf} from '@angular/common';
import {Subscription} from 'rxjs';
import {AuthService} from '../../services/auth/auth.service';
import {Router, RouterLink} from '@angular/router';

@Component({
  selector: 'app-contactlist',
  imports: [
    NgForOf,
    NgIf,
    RouterLink
  ],
  templateUrl: './contactlist.component.html',
  styleUrl: './contactlist.component.css'
})
export class ContactlistComponent implements OnInit, OnDestroy {
  contacts: BasicContactDTO[] = [];
  isLoggedIn: boolean = false;

  private subscription: Subscription = Subscription.EMPTY;
  constructor(private contactService: ContactService, private authService:AuthService, private router: Router) { }

  ngOnInit() {
    this.contactService.getAllContacts().subscribe(contacts => this.contacts = contacts);
    this.subscription = this.authService.loginChanged.subscribe(() => {
      this.checkLogin()
    });
    this.checkLogin();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  private checkLogin(): void {
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  goToCreateContact() {
    this.router.navigate(['/contacts/create']);
  }
  deleteContact(id: number) {
    this.contactService.deleteContact(id).subscribe({
      next: () =>
      {
        this.router.navigate(['/contacts']);
      },
      error: (error) => {
        console.error('Error deleting contact:', error);
      }
    });
  }
}
