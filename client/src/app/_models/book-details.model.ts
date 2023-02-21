import { IBaseBook } from "./base-book.model";
import { IReview } from "./review.model";

export interface IBookDetails extends IBaseBook {
  rating: number;
  reviews: IReview[];
}
