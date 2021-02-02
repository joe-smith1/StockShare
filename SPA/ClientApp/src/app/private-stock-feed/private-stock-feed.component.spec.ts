import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrivateStockFeedComponent } from './private-stock-feed.component';

describe('PrivateStockFeedComponent', () => {
  let component: PrivateStockFeedComponent;
  let fixture: ComponentFixture<PrivateStockFeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrivateStockFeedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrivateStockFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
