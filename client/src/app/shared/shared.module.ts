import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { TextInputComponent } from './_forms/text-input/text-input.component';
import { TextareaComponent } from './_forms/textarea/textarea.component';
import { FileUploadComponent } from './file-upload/file-upload.component';

import { LengthPipe } from '../_pipes/length.pipe';
import { TruncatePipe } from '../_pipes/truncate.pipe';

@NgModule({
  declarations: [
    TextInputComponent,
    TextareaComponent,
    FileUploadComponent,
    LengthPipe,
    TruncatePipe
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [
    TextInputComponent,
    TextareaComponent,
    FileUploadComponent,
    LengthPipe,
    TruncatePipe,
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class SharedModule { }
