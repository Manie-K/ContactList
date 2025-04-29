import {Component, OnInit} from '@angular/core';
import {ContactService} from '../../services/contact/contact.service';
import {CreateContactDTO} from '../../models/contact/CreateContactDTO';
import {Router} from '@angular/router';
import {FormsModule} from '@angular/forms';
import {CategoryService} from '../../services/category/category.service';
import {GetCategoryDTO} from '../../models/category/GetCategoryDTO';
import {NgForOf, NgIf} from '@angular/common';

@Component({
  selector: 'app-contactcreate',
  imports: [
    FormsModule,
    NgForOf,
    NgIf
  ],
  templateUrl: './contactcreate.component.html',
  styleUrl: './contactcreate.component.css'
})
export class ContactcreateComponent implements OnInit {
  firstName: string = '';
  lastName: string = '';
  email: string = '';
  password: string = '';
  category: string = '';
  subcategory: string | null = null;
  phone: string = '';
  dateOfBirth: Date = new Date();

  categories: GetCategoryDTO[] = [];
  selectedCategory: GetCategoryDTO | null = null;
  selectedSubcategory: string | null = null;
  constructor(private contactService: ContactService, private categoryService: CategoryService,
              private router: Router) { }

  ngOnInit() {
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
  createContact(): void {
    const contactData : CreateContactDTO = {
      firstName: this.firstName,
      lastName: this.lastName,
      email: this.email,
      password: this.password,
      category: this.selectedCategory? this.selectedCategory.name : "",
      subcategory: this.selectedSubcategory? this.selectedSubcategory : null,
      phone: this.phone,
      dateOfBirth: this.dateOfBirth
    };

    this.contactService.createContact(contactData).subscribe(
      (response) => {
        console.log('Contact created successfully', response);
        this.router.navigate(['/contacts']);
      },
      (error) => {
        console.error('Error creating contact', error);
        alert('Error creating contact. Please try again.');
      }
    );
  }

  onCategoryChange() {
    this.selectedSubcategory = null;
  }
}
