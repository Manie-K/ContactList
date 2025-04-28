export interface DetailContactDTO {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  category: string;
  subCategory: string | null;
  phone: string;
  dateOfBirth: Date;
}
