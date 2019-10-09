import { Component, Input } from '@angular/core';
import { CustomerLookupDto } from 'src/app/api/models';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})
export class GridComponent {
  @Input() customers: Array<CustomerLookupDto>;
  editing = 0;

  toggleEditing(id: number) {
    this.editing = id;
  }
}
