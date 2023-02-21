import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { BooksService } from 'src/app/_services/books.service';

@Component({
  selector: 'app-edit-book',
  templateUrl: './edit-book.component.html',
  styleUrls: ['./edit-book.component.css']
})
export class EditBookComponent implements OnInit, OnDestroy {
  updateMode = false;
  bookForm: FormGroup;
  bookCover: string;
  bookId: string;
  subscription: Subscription;

  constructor(private booksService: BooksService) {}

  ngOnInit() {
    this.bookForm = new FormGroup({
      title: new FormControl('', Validators.required),
      content: new FormControl('', Validators.required),
      genre: new FormControl('', Validators.required),
      author: new FormControl('', Validators.required),
      cover: new FormControl(null)
    });

    this.subscription = this.booksService.bookToEdit$.subscribe(book => {
      if (book) {
        this.updateMode = true;
        this.bookId = book.id.toString();
        this.bookForm.setValue({
          title: book.title,
          cover: null,
          genre: book.genre,
          author: book.author,
          content: book.content
        });
      }
    });
  }

  onSubmit() {
    if (!this.bookForm.valid) return;

    const updatedBook = { ...this.bookForm.value, cover: this.bookCover };

    if (this.bookId) {
      updatedBook['id'] = this.bookId;
    }

    this.booksService.saveBook(updatedBook)
      .subscribe(_ => {
        this.reset();
      });
  }

  reset() {
    this.clearForm();
    this.updateMode = false;
    this.bookId = null;
    this.bookCover = null;
  }

  clearForm() {
    this.bookForm.reset();
  }

  setBookCover(bookCover: string) {
    this.bookCover = bookCover;
  }

  ngOnDestroy() {
    if (this.subscription) this.subscription.unsubscribe();
  }
}
