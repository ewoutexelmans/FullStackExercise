import { Component, Input } from '@angular/core';
import { CustomerLookupDto } from 'src/app/api/models';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
})
export class GridComponent {
  @Input() customers: Array<CustomerLookupDto>;
}
