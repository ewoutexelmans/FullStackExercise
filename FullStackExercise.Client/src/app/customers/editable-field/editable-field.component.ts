import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-editable-field',
  templateUrl: './editable-field.component.html',
  styleUrls: ['./editable-field.component.scss']
})
export class EditableFieldComponent {
  @Input() value: string;
}
