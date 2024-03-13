import { TestBed } from '@angular/core/testing';

import { FinitionService } from './finition.service';

describe('FinitionService', () => {
  let service: FinitionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FinitionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
