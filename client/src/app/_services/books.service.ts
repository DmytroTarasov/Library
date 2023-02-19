import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { Book } from '../_models/book.model';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  private booksSource = new BehaviorSubject<Book[]>(null);
  books$ = this.booksSource.asObservable();

  constructor(private http: HttpClient) { }

  getAllBooks() {
    return this.http
      .get<Book[]>(`${environment.serverUrl}/books?order=title`);
      // .pipe(
      //   tap(books => {
      //     this.booksSource.next(books);
      //   })
      // );
  }

  getRecommendedBooks() {
    return this.http.get<Book[]>(`${environment.serverUrl}/books/recommended`);
  }
}
