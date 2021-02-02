import { template } from '@angular-devkit/schematics';
import { HttpClient } from '@angular/common/http';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { using } from 'rxjs';
import { StockFeedService } from '../services/stock-feed/stock-feed.service';
import { Stock } from '../_models/Stock';

@Component({
  selector: 'app-stock-feed',
  templateUrl: './stock-feed.component.html',
  styleUrls: ['./stock-feed.component.css']
})
export class StockFeedComponent implements OnInit {
  @Input() publicStocks: boolean = true;
  stocks: Stock[] = [];
  failed: boolean = false;
  loaded: boolean = false;


  constructor(private stockFeedService: StockFeedService) { }

  ngOnInit(): void {
    if (this.publicStocks) {
      this.stockFeedService.getPublicStocks()
        .subscribe(
            response => {this.stocks = response; this.loaded = true;},
            error => this.failed = true
          );
    }
    else {
      this.stockFeedService.getPrivateStocks()
        .subscribe(
          response => { this.stocks = response; this.loaded = true; },
          error => this.failed = true
      );

    }
  }

}
