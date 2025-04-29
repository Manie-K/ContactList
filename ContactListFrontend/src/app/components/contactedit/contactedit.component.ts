import {Component, OnInit} from '@angular/core';
import {GetCategoryDTO} from '../../models/category/GetCategoryDTO';
import {ContactService} from '../../services/contact/contact.service';
import {CategoryService} from '../../services/category/category.service';
import {ActivatedRoute, Router} from '@angular/router';
import {CreateContactDTO} from '../../models/contact/CreateContactDTO';
import {UpdateContactDTO} from '../../models/contact/UpdateContactDTO';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {NgForOf, NgIf} from '@angular/common';

@Component({
  selector: 'app-contactedit',
  imports: [
    FormsModule,
    NgForOf,
    NgIf,
    ReactiveFormsModule
  ],
  templateUrl: './contactedit.component.html',
  styleUrl: './contactedit.component.css'
})
export class ContacteditComponent implements OnInit {
  id: string | null = '';
  firstName: string = '';
  lastName: string = '';
  category: string = '';
  subcategory: string | null = null;
  phone: string = '';
  dateOfBirth: Date = new Date();

  categories: GetCategoryDTO[] = [];
  selectedCategory: GetCategoryDTO | null = null;
  selectedSubcategory: string | null = null;
  constructor(private contactService: ContactService, private categoryService: CategoryService,
              private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.contactService.getContactById(Number(this.id)).subscribe(contact => {
      this.firstName = contact.firstName;
      this.lastName = contact.lastName;
      this.selectedCategory = this.categoryService.getCategoryByName(contact.category)?? null;
      this.subcategory = contact.subcategory;
      this.selectedSubcategory = contact.subcategory;
      this.phone = contact.phone;
      this.dateOfBirth = contact.dateOfBirth;
    })


    this.categoryService.getAllCategories().subscribe(
      (categories) => {
        console.log('Categories loaded successfully', categories);
        this.categories = categories;
      },
      (error) => {
        console.error('Error loading categories', error);
        alert('Error loading categories. Please try again.');
      }
    );
  }
  updateContact(): void {
    const contactData: UpdateContactDTO = {
      firstName: this.firstName,
      lastName: this.lastName,
      category: this.selectedCategory ? this.selectedCategory.name : "",
      subcategory: this.selectedSubcategory ? this.selectedSubcategory : null,
      phone: this.phone,
      dateOfBirth: this.dateOfBirth
    };

    this.contactService.updateContact(Number(this.id), contactData).subscribe(
      (response) => {
        console.log('Contact updated successfully', response);
        this.router.navigate(['/contacts']);
      },
      (error) => {
        console.error('Error updating contact', error);
        alert('Error creating contact. Please try again.');
      }
    );
  }
  onCategoryChange():void{
    this.selectedSubcategory = null;
  }
}
