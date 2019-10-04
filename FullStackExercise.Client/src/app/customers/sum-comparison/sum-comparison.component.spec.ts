import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SumComparisonComponent } from './sum-comparison.component';

describe('SumComparisonComponent', () => {
  let component: SumComparisonComponent;
  let fixture: ComponentFixture<SumComparisonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SumComparisonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SumComparisonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
