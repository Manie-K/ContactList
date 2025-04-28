export interface CreateContactDTO {
  firstName: string;
  lastName: string;
  email: string;
  category: string;
  subcategory: string | null;
  phone: string;
  dateOfBirth: Date;
}
