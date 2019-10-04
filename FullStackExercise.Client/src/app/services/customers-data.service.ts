import { Injectable } from '@angular/core';
import { CustomersService } from '../api/services';
import { BehaviorSubject, combineLatest, Observable } from 'rxjs';
import { flatMap, publish, refCount } from 'rxjs/operators';
import { GetCustomersByPageResponse, FilterType } from '../api/models';

@Injectable({
  providedIn: 'root'
})
export class CustomersDataService {
  private pageIndexSubject$ = new BehaviorSubject<number>(0);
  private pageSizeSubject$ = new BehaviorSubject<number>(10);
  private keyWordSubject$ = new BehaviorSubject<string>('');
  private filtersSubject$ = new BehaviorSubject<Array<FilterType>>([]);

  public customersPaged$: Observable<
    GetCustomersByPageResponse
  > = combineLatest(
    this.pageIndexSubject$,
    this.pageSizeSubject$,
    this.keyWordSubject$,
    this.filtersSubject$
  ).pipe(
    flatMap(([pageIndex, pageSize, keyWord, filters]) =>
      this.data.getPagedCustomers$Json({
        pageIndex,
        pageSize,
        keyWord,
        filters
      })
    ),
    publish(),
    refCount()
  );

  constructor(private data: CustomersService) {}

  getCustomers(pageIndex = 0) {
    this.pageIndexSubject$.next(pageIndex);
  }

  updatePageSize(pageSize: number) {
    this.pageSizeSubject$.next(pageSize);
  }

  filterCustomers(keyWord: string) {
    this.keyWordSubject$.next(keyWord);
  }

  updateFilters(filters: Array<FilterType>) {
    this.filtersSubject$.next(filters);
  }
}
