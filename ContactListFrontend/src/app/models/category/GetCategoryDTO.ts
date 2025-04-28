export interface GetCategoryDTO {
  id: number;
  name: string;
  allowCustomSubcategory: boolean;
  subcategories: string[];
}
