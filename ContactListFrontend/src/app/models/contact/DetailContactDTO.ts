﻿export interface DetailContactDTO {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  category: string;
  subcategory: string | null;
  phone: string;
  dateOfBirth: Date;
}
