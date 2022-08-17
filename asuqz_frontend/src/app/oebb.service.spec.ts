import { TestBed } from '@angular/core/testing';

import { OebbService } from './oebb.service';

describe('OebbService', () => {
  let service: OebbService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OebbService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
