import { Component, Input, OnInit } from '@angular/core';
import { BsDropdownConfig } from 'ngx-bootstrap/dropdown';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { StockFeedService } from '../services/stock-feed/stock-feed.service';
import { PaginatedList } from '../_models/PaginatedList';
import { Stock } from '../_models/Stock';
import { StockParams } from '../_models/StockParams';

@Component({
  selector: 'app-stock-feed',
  templateUrl: './stock-feed.component.html',
  styleUrls: ['./stock-feed.component.css'],
  providers: [{provide: BsDropdownConfig, useValue: {isAnimated: true, autoClose: true}}]
})
export class StockFeedComponent implements OnInit {
  @Input() publicStocks: boolean = true;
  stocks: PaginatedList<Stock>;
  stockParams: StockParams;
  failed: boolean = false;
  loaded: boolean = false;


  constructor(private stockFeedService: StockFeedService) {
    this.stockParams = stockFeedService.getStockParams();
    this.stockParams.pageNumber = 1;
    this.updateStockParams();
  }

  ngOnInit(): void {
    this.loadStocks();
  }

  loadStocks() {
    if (this.publicStocks) {
      this.stockFeedService.getPublicStocks()
        .subscribe(
            response => {this.stocks = response; this.loaded = true;},
            () => this.failed = true
          );
    }
    else {
      this.stockFeedService.getPrivateStocks()
        .subscribe(
          response => { this.stocks = response; this.loaded = true; },
          () => this.failed = true
      );

    }
  }

  pageChanged(event: PageChangedEvent) {
    this.stockParams.pageNumber = event.page;
    this.updateStockParams();
  }

  paginationSizeChange(pageSize: number): void {
    this.stockParams.pageSize = pageSize;
    this.stockParams.pageNumber = 1;
    this.updateStockParams();
  }

  private updateStockParams() {
    this.stockFeedService.setStockParams(this.stockParams);
    this.loadStocks();
  }

}
