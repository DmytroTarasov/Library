import { Component, EventEmitter, HostListener, Input, Output, Self } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent implements ControlValueAccessor {
  onChange: Function;
  previewUrl: string;
  @Output() bookCoverSelected: EventEmitter<string> = new EventEmitter<string>();

  constructor(@Self() public ngControl: NgControl) {
    this.ngControl.valueAccessor = this;
  }

  @HostListener('change', ['$event.target.files']) emitFiles(event: FileList) {
    const file = event && event.item(0);
    this.onChange(file);

    const fileReader = new FileReader();

    fileReader.onload = () => {
      this.previewUrl = fileReader.result.toString();
      this.bookCoverSelected.emit(this.previewUrl);
    }

    fileReader.readAsDataURL(file);
  }

  writeValue(value: any) {}

  registerOnChange(fn: Function) {
    this.onChange = fn;
  }

  registerOnTouched(fn: Function) {}
}
