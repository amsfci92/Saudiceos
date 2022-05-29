import { NewsList } from './news';

export interface CeoList {
  id: number;
  image: string;
  cvUrl: string;
  company: string;
  createdDate: string;
  cvDescription: string;
  cvNote: string;
  imageUrl: string;
  nationalIDImageUrl: string;
  linkedIn: string;
  name: string;
  twitter: string;
  position: string;
  email: string;
  ceoNews: Array<NewsList>;
}

export interface AddNewCeo {
  imageUrl: string;
  nationalIDImageUrl: string;
  name: string;
  position: string;
  email: string;
  phone: string;
  cvDescription: string;
  cvUrl: string;
}

export interface UpdateCeo {
  imageUrl: string;
  name: string;
  position: string;
  email: string;
  phone: string;
  cvDescription: string;
  cvUrl: string;
  ceoId: number;
}
