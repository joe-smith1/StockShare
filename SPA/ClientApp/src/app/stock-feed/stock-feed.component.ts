import { template } from '@angular-devkit/schematics';
import { HttpClient } from '@angular/common/http';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { using } from 'rxjs';
import { StockFeedService } from '../services/stock-feed/stock-feed.service';
import { PaginatedList } from '../_models/PaginatedList';
import { Stock } from '../_models/Stock';
import { StockParams } from '../_models/StockParams';

@Component({
  selector: 'app-stock-feed',
  templateUrl: './stock-feed.component.html',
  styleUrls: ['./stock-feed.component.css']
})
export class StockFeedComponent implements OnInit {
  @Input() publicStocks: boolean = true;
  stocks: PaginatedList<Stock>;
  stockParams: StockParams;
  failed: boolean = false;
  loaded: boolean = false;


  constructor(private stockFeedService: StockFeedService) {
    this.stockParams = new StockParams();
  }

  ngOnInit(): void {
    this.loadStocks();
  }

  loadStocks() {
    if (this.publicStocks) {
      this.stockFeedService.getPublicStocks(this.stockParams)
        .subscribe(
            response => {this.stocks = response; this.loaded = true;},
            error => this.failed = true
          );
    }
    else {
      this.stockFeedService.getPrivateStocks(this.stockParams)
        .subscribe(
          response => { this.stocks = response; this.loaded = true; },
          error => this.failed = true
      );

    }
  }

  pageChanged(event: PageChangedEvent) {
    this.stockParams.pageNumber = event.page;
    this.loadStocks();
  }

}
