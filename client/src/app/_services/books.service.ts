import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { IBookDetails } from '../_models/book-details.model';
import { IBook } from '../_models/book.model';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  private booksSource = new BehaviorSubject<IBook[]>(null);
  books$ = this.booksSource.asObservable();

  constructor(private http: HttpClient) { }

  getAllBooks() {
    return this.http
      .get<IBook[]>(`${environment.serverUrl}/books?order=title`);
      // .pipe(
      //   tap(books => {
      //     this.booksSource.next(books);
      //   })
      // );
  }

  getRecommendedBooks() {
    return this.http.get<IBook[]>(`${environment.serverUrl}/books/recommended`);
  }

  getBookDetails(bookId: number) {
    return this.http.get<IBookDetails>(`${environment.serverUrl}/books/${bookId}`);
  }
}
