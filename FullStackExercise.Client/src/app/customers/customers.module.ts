import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CustomersRoutingModule } from './customers-routing.module';
import { SharedModule } from '../shared/shared.module';
import { GridComponent } from './grid/grid.component';
import { PaginationComponent } from './pagination/pagination.component';
import { FilterComponent } from './filter/filter.component';
import { SumComparisonComponent } from './sum-comparison/sum-comparison.component';

@NgModule({
  declarations: [DashboardComponent, GridComponent, PaginationComponent, FilterComponent, SumComparisonComponent],
  imports: [CommonModule, CustomersRoutingModule, SharedModule]
})
export class CustomersModule {}
