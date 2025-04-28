import {Component, OnInit} from '@angular/core';
import {ContactService} from '../../services/contact/contact.service';
import {DetailContactDTO} from '../../models/contact/DetailContactDTO';
import {ActivatedRoute, RouterLink} from '@angular/router';
import {NgIf} from '@angular/common';

@Component({
  selector: 'app-contactdetail',
  imports: [RouterLink, NgIf],
  templateUrl: './contactdetail.component.html',
  styleUrl: './contactdetail.component.css'
})
export class ContactdetailComponent implements OnInit {
  contact: DetailContactDTO | null = null;
  id: string = '';
  constructor(private contactService: ContactService, private route: ActivatedRoute) { }

  ngOnInit() {
      this.route.params.subscribe(params => {this.id = params['id'];});
      this.contactService.getContactById(Number(this.id)).subscribe(contact => {
        this.contact = contact;
        console.log(contact);
      });
  }
}
