import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss']
})
export class PaginationComponent {
  @Input() pageCount: number;
  @Output() changePageIndex = new EventEmitter<number>();
  @Output() changePageSize = new EventEmitter<number>();
  index = 0;
  sizeOptions = [10, 25, 50, 100];

  nextPage() {
    this.next(() => this.index++);
  }

  lastPage() {
    this.next(() => (this.index = this.pageCount - 1));
  }

  previousPage() {
    this.previous(() => this.index--);
  }

  firstPage() {
    this.previous(() => (this.index = 0));
  }

  next(fn: () => void) {
    if (this.index < this.pageCount - 1) {
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

  changeIndex() {
    this.changePageIndex.emit(this.index);
  }

  changeSize(size: string) {
    this.changePageSize.emit(+size);
  }
}
