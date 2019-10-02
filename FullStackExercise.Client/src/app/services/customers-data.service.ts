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
    filter(([page, pageSize]) => page > 0 && pageSize > 0),
    flatMap(([page, pageSize]) =>
      this.data.getPagedCustomers$Plain({ page, pageSize })
    ),
    publish(),
    refCount()
  );

  constructor(private data: CustomersService) {}

  getCustomers(page = 1) {
    this.pageSubject$.next(page);
  }

  updatePageCount(pageSize: number) {
    this.pageSizeSubject$.next(pageSize);
  }
}
