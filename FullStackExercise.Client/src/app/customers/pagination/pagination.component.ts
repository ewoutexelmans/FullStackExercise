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
    if (this.index < this.pageCount) {
      this.index++;
      this.changeIndex();
    }
  }

  previousPage() {
    if (this.index > 0) {
      this.index--;
      this.changeIndex();
    }
  }

  changeIndex() {
    this.changePageIndex.emit(this.index);
  }

  changeSize(size: number) {
    this.changePageSize.emit(size);
  }
}
