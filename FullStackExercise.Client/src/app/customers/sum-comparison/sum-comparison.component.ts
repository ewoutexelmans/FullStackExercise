import { Component, Output, EventEmitter } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-sum-comparison',
  templateUrl: './sum-comparison.component.html'
})
export class SumComparisonComponent {
  @Output() higherLowerChange = new EventEmitter<boolean | null>();
  @Output() sumComparisonChange = new Observable<number>();

  sumComparisonSubject$ = new Subject<number>();
  higherLower?: boolean;

  constructor() {
    this.sumComparisonChange = this.sumComparisonSubject$.pipe(
      debounceTime(1000),
      distinctUntilChanged()
    );
  }

  filter(higherLower?: boolean) {
    this.higherLower = higherLower;
    this.higherLowerChange.emit(this.higherLower);
  }

  updateSum(sum: string) {
    this.sumComparisonSubject$.next(+sum);
  }
}
