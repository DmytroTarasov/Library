import { Component, Input } from '@angular/core';
import { Book } from 'src/app/_models/book.model';

@Component({
  selector: 'app-book-list-item',
  templateUrl: './book-list-item.component.html',
  styleUrls: ['./book-list-item.component.css']
})
export class BookListItemComponent {
  @Input('book') book: Book;
}
