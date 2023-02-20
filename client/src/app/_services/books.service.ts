import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { IBookDetails } from '../_models/book-details.model';
import { IBook } from '../_models/book.model';
import { ISaveBook } from '../_models/save-book.model';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  private booksChangeSource = new BehaviorSubject<boolean>(false);
  booksChange$ = this.booksChangeSource.asObservable();

  constructor(private http: HttpClient) { }

  getAllBooks() {
    return this.http
      .get<IBook[]>(`${environment.serverUrl}/books?order=title`)
      .pipe(
        tap(_ => {
          this.booksChangeSource.next(false);
        })
      )
  }

  getRecommendedBooks() {
    return this.http
      .get<IBook[]>(`${environment.serverUrl}/books/recommended`)
      .pipe(
        tap(_ => {
          this.booksChangeSource.next(false);
        })
      )
  }

  getBookDetails(bookId: number) {
    return this.http.get<IBookDetails>(`${environment.serverUrl}/books/${bookId}`);
  }

  addBook(book: ISaveBook) {
    return this.http
      .post<number>(`${environment.serverUrl}/books/save`, book)
      .pipe(
        tap(_ => {
          this.booksChangeSource.next(true);
        })
      );
  }
}
