import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss']
})
export class PaginationComponent {
  @Input() pageCount: number;
  @Input() pageIndex: number;

  @Output() changePageIndex = new EventEmitter<number>();
  @Output() changePageSize = new EventEmitter<number>();

  pageSizeOptions = [10, 25, 50, 100];

  nextPage() {
    this.next(() => this.pageIndex++);
  }

  lastPage() {
    this.next(() => (this.pageIndex = this.pageCount - 1));
  }

  previousPage() {
    this.previous(() => this.pageIndex--);
  }

  firstPage() {
    this.previous(() => (this.pageIndex = 0));
  }

  next(fn: () => void) {
    if (this.pageIndex < this.pageCount - 1) {
      fn();
      this.changeIndex();
    }
  }

  previous(fn: () => void) {
    if (this.pageIndex > 0) {
      fn();
      this.changeIndex();
    }
  }

  changeIndex() {
    this.changePageIndex.emit(this.pageIndex);
    console.log(this.pageCount);
  }

  changeSize(size: string) {
    this.changePageSize.emit(+size);
  }
}
