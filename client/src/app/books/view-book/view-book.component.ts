import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { IBookDetails } from 'src/app/_models/book-details.model';
import { BooksService } from 'src/app/_services/books.service';

@Component({
  selector: 'app-view-book',
  templateUrl: './view-book.component.html',
  styleUrls: ['./view-book.component.css']
})
export class ViewBookComponent implements OnInit {
  @Input() bookId: number;
  @Output() closeModal: EventEmitter<any> = new EventEmitter<any>();
  book$: Observable<IBookDetails>;

  constructor(private booksService: BooksService) {}

  ngOnInit() {
    this.book$ = this.booksService.getBookDetails(this.bookId);
  }

  closeModalDialog() {
    this.closeModal.emit();
  }
}
