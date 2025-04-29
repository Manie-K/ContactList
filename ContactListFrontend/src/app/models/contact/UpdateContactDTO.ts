export interface UpdateContactDTO {
  firstName: string;
  lastName: string;
  category: string;
  subcategory: string | null;
  phone: string;
  dateOfBirth: Date;
}
