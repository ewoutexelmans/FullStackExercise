import { Component, Input, OnInit } from '@angular/core';
import { CustomerLookupDto } from 'src/app/api/models';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})
export class GridComponent implements OnInit {
  @Input() customers: Array<CustomerLookupDto>;

  editing = 0;
  form = this.formBuilder.group({
    firstName: [''],
    lastName: ['']
  });

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit() {
    this.form.valueChanges.subscribe(newVal => console.log(newVal));
  }

  toggleEditing(id: number) {
    this.editing = id;
  }
}
