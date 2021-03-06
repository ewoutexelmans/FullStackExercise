import { Component, Output, EventEmitter } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { FilterType } from 'src/app/api/models';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html'
})
export class FilterComponent {
  @Output() keyWordChange = new Observable<string>();
  @Output() activeFiltersChange = new EventEmitter<Array<FilterType>>();

  keyWordSubject$ = new Subject<string>();
  filters: Array<FilterType> = [];

  constructor() {
    this.keyWordChange = this.keyWordSubject$.pipe(
      debounceTime(1000),
      distinctUntilChanged()
    );
  }

  filter(keyWord: string) {
    this.keyWordSubject$.next(keyWord.trim());
  }

  toggleFilterType(filterType: FilterType) {
    if (this.filters.includes(filterType)) {
      this.filters = this.filters.filter(f => f !== filterType);
    } else {
      this.filters.push(filterType);
    }
    this.changeFilters();
  }

  clear() {
    this.filters = [];
    this.changeFilters();
  }

  changeFilters() {
    this.activeFiltersChange.emit(this.filters);
  }
}
