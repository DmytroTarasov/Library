import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FontAwesomeModule, FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faEdit, faEye } from '@fortawesome/free-regular-svg-icons';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NgxSpinnerModule } from 'ngx-spinner';

import { AppComponent } from './app.component';
import { BookListComponent } from './books/book-list/book-list.component';
import { BookListItemComponent } from './books/book-list-item/book-list-item.component';

import { ViewBookComponent } from './books/view-book/view-book.component';
import { EditBookComponent } from './books/edit-book/edit-book.component';
import { TextInputComponent } from './shared/_forms/text-input/text-input.component';
import { TextareaComponent } from './shared/_forms/textarea/textarea.component';
import { FileUploadComponent } from './shared/file-upload/file-upload.component';
import { LengthPipe } from './_pipes/length.pipe';
import { TruncatePipe } from './_pipes/truncate.pipe';
import { LoadingInterceptor } from './_interceptors/loading.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    BookListComponent,
    BookListItemComponent,
    ViewBookComponent,
    EditBookComponent,
    TextInputComponent,
    TextareaComponent,
    FileUploadComponent,
    LengthPipe,
    TruncatePipe
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    TabsModule.forRoot(),
    ModalModule.forRoot(),
    FontAwesomeModule,
    NgxSpinnerModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true }
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {
  constructor(library: FaIconLibrary) {
    library.addIcons(faEdit, faEye);
  }
}
