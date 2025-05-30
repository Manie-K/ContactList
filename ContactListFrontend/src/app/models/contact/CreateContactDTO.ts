﻿export interface CreateContactDTO {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  category: string;
  subcategory: string | null;
  phone: string;
  dateOfBirth: Date;
}
