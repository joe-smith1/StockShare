import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StockFeedComponent } from './stock-feed.component';

describe('StockFeedComponent', () => {
  let component: StockFeedComponent;
  let fixture: ComponentFixture<StockFeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StockFeedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StockFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
