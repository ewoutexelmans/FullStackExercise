import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CustomerLookupDto } from 'src/app/api/models';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})
export class GridComponent {
  @Input() customers: Array<CustomerLookupDto>;
  @Output() customerChange = new EventEmitter<CustomerLookupDto>();

  editId = 0;
  form = this.formBuilder.group({
    firstName: [''],
    lastName: ['']
  });

  constructor(private formBuilder: FormBuilder) {}

  toggleEditing(id: number) {
    this.form.reset();
    this.editId = id;
  }

  onSubmit() {
    const customer = this.form.value as CustomerLookupDto;
    this.customerChange.emit(customer);
    this.toggleEditing(0);
  }

  onReset() {
    this.toggleEditing(0);
  }
}
