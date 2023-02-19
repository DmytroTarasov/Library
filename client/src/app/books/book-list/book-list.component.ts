import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from 'src/app/_models/book.model';
import { BooksService } from 'src/app/_services/books.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  @Input('recommended') recommended: boolean;

  books$: Observable<Book[]>;

  constructor(private booksService: BooksService) { }

  ngOnInit() {
    this.books$ = this.recommended
      ? this.booksService.getRecommendedBooks()
      : this.booksService.getAllBooks();

    // this.books$ = this.booksService.books$;
  }
}
