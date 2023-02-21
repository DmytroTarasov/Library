import { Component, Input, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { IBaseBook } from 'src/app/_models/base-book.model';
import { IBook } from 'src/app/_models/book.model';
import { BooksService } from 'src/app/_services/books.service';

@Component({
  selector: 'app-book-list-item',
  templateUrl: './book-list-item.component.html',
  styleUrls: ['./book-list-item.component.css']
})
export class BookListItemComponent {
  @Input() book: IBook;
  modalRef?: BsModalRef;

  constructor(private modalService: BsModalService, private booksService: BooksService) {}

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  closeModal() {
    this.modalRef?.hide();
  }

  setBookToEdit(book: IBaseBook) {
    this.booksService.setBookToEdit(book);
  }
}
