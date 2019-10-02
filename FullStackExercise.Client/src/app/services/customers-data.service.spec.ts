import { TestBed } from '@angular/core/testing';

import { CustomersDataService } from './customers-data.service';

describe('CustomersDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CustomersDataService = TestBed.get(CustomersDataService);
    expect(service).toBeTruthy();
  });
});
