import { Injectable } from '@angular/core';
import { CustomersService } from '../api/services';
import { BehaviorSubject, combineLatest, Observable } from 'rxjs';
import { filter, flatMap, publish, refCount } from 'rxjs/operators';
import { GetCustomersByPageResponse } from '../api/models';

@Injectable({
  providedIn: 'root'
})
export class CustomersDataService {
  private pageSubject$ = new BehaviorSubject<number>(0);
  private pageSizeSubject$ = new BehaviorSubject<number>(10);

  public response$: Observable<GetCustomersByPageResponse> = combineLatest(
    this.pageSubject$,
    this.pageSizeSubject$
  ).pipe(
    filter(([pageIndex, pageSize]) => pageIndex >= 0 && pageSize > 0),
    flatMap(([pageIndex, pageSize]) =>
      this.data.getPagedCustomers$Plain({ pageIndex, pageSize })
    ),
    publish(),
    refCount()
  );

  constructor(private data: CustomersService) {}

  getCustomers(pageIndex = 0) {
    this.pageSubject$.next(pageIndex);
  }

  updatePageCount(pageSize: number) {
    this.pageSizeSubject$.next(pageSize);
  }
}
