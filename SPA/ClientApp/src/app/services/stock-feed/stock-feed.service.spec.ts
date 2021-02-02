import { TestBed } from '@angular/core/testing';

import { StockFeedService } from './stock-feed.service';

describe('StockFeedServiceService', () => {
  let service: StockFeedServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StockFeedServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
