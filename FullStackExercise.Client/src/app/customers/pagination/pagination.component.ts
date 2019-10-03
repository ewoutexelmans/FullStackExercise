import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html'
})
export class PaginationComponent {
  @Input() pageCount: number;
  @Output() changePageIndex = new EventEmitter<number>();
  @Output() changePageSize = new EventEmitter<number>();
  index = 0;

  nextPage() {
    this.next(() => this.index++);
  }

  last() {
    this.next(() => (this.index = this.pageCount));
  }

  previousPage() {
    this.previous(() => this.index--);
  }

  first() {
    this.previous(() => (this.index = 0));
  }

  next(fn: () => void) {
    if (this.index < this.pageCount) {
      fn();
      this.changeIndex();
    }
  }

  previous(fn: () => void) {
    if (this.index > 0) {
      fn();
      this.changeIndex();
    }
  }

  firstPage() {
    if (this.index > 0) {
    }
  }

  changeIndex() {
    this.changePageIndex.emit(this.index);
  }

  changeSize(size: number) {
    this.changePageSize.emit(size);
  }
}
