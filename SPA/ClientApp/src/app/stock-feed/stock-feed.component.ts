import { template } from '@angular-devkit/schematics';
import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { using } from 'rxjs';
import { Stock } from '../_models/Stock';

@Component({
  selector: 'app-stock-feed',
  templateUrl: './stock-feed.component.html',
  styleUrls: ['./stock-feed.component.css']
})
export class StockFeedComponent implements OnInit {
  stocks: Stock[] = [];
  failed: boolean = false;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit(): void {
    this.httpClient.get<Stock[]>(this.baseUrl + 'api/stockfeed/all')
      .subscribe(
        response => this.stocks = response,
        error => this.failed = true
      );
  }

}
