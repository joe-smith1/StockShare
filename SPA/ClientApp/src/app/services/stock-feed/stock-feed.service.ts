import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { getPagination, getPaginationHeaders } from 'src/app/_helpers/pagination-helpers';
import { PaginatedList } from 'src/app/_models/PaginatedList';
import { Stock } from 'src/app/_models/Stock';
import { StockParams } from 'src/app/_models/StockParams';

@Injectable({
  providedIn: 'root'
})
export class StockFeedService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getPublicStocks(stockParams: StockParams): Observable<PaginatedList<Stock>> {
    return getPagination<Stock>(
      this.baseUrl + 'api/stockfeed/all-public',
      getPaginationHeaders(stockParams.pageNumber, stockParams.pageSize),
      this.httpClient);
  }

  getPrivateStocks(stockParams: StockParams): Observable<PaginatedList<Stock>> {
    return getPagination<Stock>(
      this.baseUrl + "api/stockfeed/all-private",
      getPaginationHeaders(stockParams.pageNumber, stockParams.pageSize),
      this.httpClient);
  }
}
