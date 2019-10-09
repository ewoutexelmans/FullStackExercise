import { Injectable } from '@angular/core';
import { CustomersService } from '../api/services';
import { BehaviorSubject, combineLatest, Observable } from 'rxjs';
import { flatMap, publish, refCount } from 'rxjs/operators';
import {
  GetCustomersByPageResponse,
  FilterType,
  CustomerLookupDto
} from '../api/models';
import { invokeRequest } from '../util/invoke-request';

@Injectable({
  providedIn: 'root'
})
export class CustomersDataService {
  private refreshSubject$ = new BehaviorSubject(null);
  private pageIndexSubject$ = new BehaviorSubject<number>(0);
  private pageSizeSubject$ = new BehaviorSubject<number>(10);
  private keyWordSubject$ = new BehaviorSubject<string>('');
  private filtersSubject$ = new BehaviorSubject<Array<FilterType>>([]);
  private higherLowerSubject$ = new BehaviorSubject<boolean>(null);
  private sumComparisonSubject$ = new BehaviorSubject<number>(0);

  public customersPaged$: Observable<
    GetCustomersByPageResponse
  > = combineLatest(
    this.pageIndexSubject$,
    this.pageSizeSubject$,
    this.keyWordSubject$,
    this.filtersSubject$,
    this.higherLowerSubject$,
    this.sumComparisonSubject$,
    this.refreshSubject$
  ).pipe(
    flatMap(
      ([pageIndex, pageSize, keyWord, filters, higherLower, sumComparison]) =>
        this.data.getPagedCustomers$Json({
          pageIndex,
          pageSize,
          keyWord,
          sumComparison,
          filters,
          higherLower
        })
    ),
    publish(),
    refCount()
  );

  private refresh = () => this.refreshSubject$.next(null);

  constructor(private data: CustomersService) {}

  getCustomers(pageIndex = 0) {
    this.pageIndexSubject$.next(pageIndex);
  }

  changePageSize(pageSize: number) {
    this.pageSizeSubject$.next(pageSize);
  }

  filterCustomers(keyWord: string) {
    this.keyWordSubject$.next(keyWord);
  }

  changeFilters(filters: Array<FilterType>) {
    this.filtersSubject$.next(filters);
  }

  filterSum(sumComparison = 0) {
    this.sumComparisonSubject$.next(sumComparison);
  }

  changeHigherLower(higherLower?: boolean) {
    this.higherLowerSubject$.next(higherLower);
  }

  updateCustomer(customer: CustomerLookupDto) {
    invokeRequest(
      this.data.updateCustomer$Json({
        body: {
          customerId: customer.customerId,
          firstName: customer.firstName,
          lastName: customer.lastName
        }
      }),
      this.refresh
    );
  }
}
