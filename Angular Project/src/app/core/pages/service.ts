export interface ServiceCategoryList {
  imageUrl: string;
  name: string;
  servicesList: Array<ServiceList>;
}

export interface ServiceList {
  id: 8;
  categoryId: number;
  dateCreated: string;
  description: string;
  imageUrl: string;
  logoUrl: string;
  backgroundImage: string;
  code: string;
  link: string;
  title: string;
}
