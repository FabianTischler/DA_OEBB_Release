import { TestBed } from '@angular/core/testing';

import { ErrorMockingService } from './error-mocking.service';

describe('ErrorMockingService', () => {
  let service: ErrorMockingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ErrorMockingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
