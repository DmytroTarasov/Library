import { IReview } from "./review.model";

export interface IBookDetails {
  id: number;
  title: string;
  cover: string;
  content: string;
  author: string;
  genre: string;
  rating: number;
  reviews: IReview[];
}
