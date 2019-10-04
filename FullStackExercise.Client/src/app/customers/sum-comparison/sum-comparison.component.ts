import { Component, Output, EventEmitter } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-sum-comparison',
  templateUrl: './sum-comparison.component.html'
})
export class SumComparisonComponent {
  @Output() changeHigherLower = new EventEmitter<boolean | null>();
  @Output() changeSumComparison = new Observable<number>();

  sumComparisonSubject$ = new Subject<number>();
  higherLower?: boolean;

  constructor() {
    this.changeSumComparison = this.sumComparisonSubject$.pipe(
      debounceTime(1000),
      distinctUntilChanged()
    );
  }

  filter(higherLower?: boolean) {
    this.higherLower = higherLower;
    this.changeHigherLower.emit(this.higherLower);
  }

  updateSum(sum: string) {
    this.sumComparisonSubject$.next(+sum);
  }
}
