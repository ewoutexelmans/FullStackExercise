import { Component, OnInit } from '@angular/core';
import { CustomersDataService } from 'src/app/services/customers-data.service';
import { FilterType } from 'src/app/api/models';

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

  filterCustomers(keyWord: string) {
    this.data.filterCustomers(keyWord);
  }

  changeFilters(filters: Array<FilterType>) {
    this.data.updateFilters(filters);
  }

  filterSum(sum: number) {
    this.data.filterSum(sum);
  }

  changeHigherLower(higherLower?: boolean) {
    this.data.updateHigherLower(higherLower);
  }
}
