import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BookListComponent } from './books/book-list/book-list.component';
import { BookListItemComponent } from './books/book-list-item/book-list-item.component';

import { TabsModule } from 'ngx-bootstrap/tabs';
import { TruncatePipe } from './_pipes/truncate.pipe';
import { FontAwesomeModule, FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';

import { faEdit, faEye } from '@fortawesome/free-regular-svg-icons';
import { ViewBookComponent } from './books/view-book/view-book.component';
import { LengthPipe } from './_pipes/length.pipe';
import { EditBookComponent } from './books/edit-book/edit-book.component';
import { TextInputComponent } from './shared/_forms/text-input/text-input.component';
import { TextareaComponent } from './shared/_forms/textarea/textarea.component';
import { FileUploadComponent } from './shared/file-upload/file-upload.component';

@NgModule({
  declarations: [
    AppComponent,
    BookListComponent,
    BookListItemComponent,
    TruncatePipe,
    ViewBookComponent,
    LengthPipe,
    EditBookComponent,
    TextInputComponent,
    TextareaComponent,
    FileUploadComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    TabsModule.forRoot(),
    ModalModule.forRoot(),
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(library: FaIconLibrary) {
    library.addIcons(faEdit, faEye);
  }
}
