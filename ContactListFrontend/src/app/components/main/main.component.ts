import {Component, OnDestroy, OnInit} from '@angular/core';
import {RouterLink, RouterOutlet} from '@angular/router';
import {Subscription} from 'rxjs';
import {AuthService} from '../../services/auth/auth.service';
import {NgIf} from '@angular/common';

@Component({
  selector: 'app-main',
  imports: [
    RouterOutlet,
    NgIf,
    RouterLink
  ],
  templateUrl: './main.component.html',
  styleUrl: './main.component.css'
})
export class MainComponent implements OnInit, OnDestroy {
  username: string = '';
  isLoggedIn: boolean = false;

  private subscription: Subscription = Subscription.EMPTY;

  constructor(protected authService: AuthService)
  {
  }
  ngOnInit() {
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
    this.username = this.authService.getUsername();
  }
}
