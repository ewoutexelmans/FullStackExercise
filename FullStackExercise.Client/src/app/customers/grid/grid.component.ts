import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CustomerLookupDto, UpdateCustomerCommand } from 'src/app/api/models';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})
export class GridComponent {
  @Input() customers: Array<CustomerLookupDto>;
  @Output() customerUpdate = new EventEmitter<UpdateCustomerCommand>();

  editId = 0;
  form = this.formBuilder.group({
    firstName: [''],
    lastName: ['']
  });

  constructor(private formBuilder: FormBuilder) {}

  toggleEditing(customer: CustomerLookupDto) {
    this.form.setValue({
      firstName: customer.firstName,
      lastName: customer.lastName
    });
    this.editId = customer.customerId;
  }

  onSubmit() {
    const customer = this.form.value as UpdateCustomerCommand;
    customer.customerId = this.editId;
    this.customerUpdate.emit(customer);
    this.form.markAsPristine();
    this.editId = 0;
  }

  onReset() {
    this.form.reset();
    this.editId = 0;
  }
}
