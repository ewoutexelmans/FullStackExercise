import { Component, OnInit } from '@angular/core';
import { CustomersDataService } from 'src/app/services/customers-data.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent implements OnInit {
  customersPaged$ = this.data.customersPaged$;

  constructor(private data: CustomersDataService) {}

  ngOnInit() {
    this.data.getCustomers();
  }

  changePageIndex(id: number) {
    this.data.getCustomers(id);
  }

  changePageSize(size: number) {
    this.data.updatePageSize(size);
  }
}
