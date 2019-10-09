import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-editable-field',
  templateUrl: './editable-field.component.html'
})
export class EditableFieldComponent {
  @Input() value: string;
  @Output() valueChange = new EventEmitter<string>();
  @Input() editing: boolean;

  onKey(value: string) {
    this.value = value;
  }
}
