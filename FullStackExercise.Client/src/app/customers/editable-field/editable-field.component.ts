import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-editable-field',
  templateUrl: './editable-field.component.html'
})
export class EditableFieldComponent {
  @Input() parentForm: FormGroup;
  @Input() placeholder: { name: string; value: string };
  @Input() editing: boolean;
}
