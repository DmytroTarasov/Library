import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BooksService } from 'src/app/_services/books.service';

@Component({
  selector: 'app-edit-book',
  templateUrl: './edit-book.component.html',
  styleUrls: ['./edit-book.component.css']
})
export class EditBookComponent implements OnInit {
  updateMode = false;
  bookForm: FormGroup;
  bookCover: string;

  constructor(private booksService: BooksService) {}

  ngOnInit() {
    this.bookForm = new FormGroup({
      title: new FormControl('', Validators.required),
      content: new FormControl('', Validators.required),
      genre: new FormControl('', Validators.required),
      author: new FormControl('', Validators.required),
      cover: new FormControl(null)
    });
  }

  onSubmit() {
    if (!this.bookForm.valid) return;
    this.booksService
      .addBook({ ...this.bookForm.value, cover: this.bookCover })
      .subscribe(_ => {
        this.clearForm();
      });
  }

  clearForm() {
    this.bookForm.reset();
  }

  setBookCover(bookCover: string) {
    this.bookCover = bookCover;
  }
}
