import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { IBook } from 'src/app/_models/book.model';
import { BooksService } from 'src/app/_services/books.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit, OnDestroy {
  @Input('recommended') recommended: boolean;

  books$: Observable<IBook[]>;
  subscription: Subscription;

  constructor(private booksService: BooksService) { }

  ngOnInit() {
    this.loadBookList();

    this.subscription = this.booksService.booksChange$.subscribe(bookChange => {
      if (bookChange) this.loadBookList();
    });
  }

  loadBookList() {
    this.books$ = this.recommended
      ? this.booksService.getRecommendedBooks()
      : this.booksService.getAllBooks();
  }

  ngOnDestroy() {
    if (this.subscription) this.subscription.unsubscribe();
  }
}
