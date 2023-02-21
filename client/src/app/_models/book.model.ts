import { IBaseBook } from "./base-book.model";

export interface IBook extends IBaseBook {
  reviewsNumber: number;
  rating: number;
}
