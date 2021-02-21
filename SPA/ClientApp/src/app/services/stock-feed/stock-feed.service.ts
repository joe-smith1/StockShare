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
  private stockParams: StockParams;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    /*
    Storing the stock params in the service as it is a singleton throughout the client whereas
    the component is scoped and wouldn't remember the user preferences after changing page.
    Also this remembers the users stock feed preference across public and profile feeds.
    */

    this.stockParams = new StockParams();
  }

  getPublicStocks(): Observable<PaginatedList<Stock>> {
    return getPagination<Stock>(
      this.baseUrl + 'api/stockfeed/all-public',
      getPaginationHeaders(this.stockParams.pageNumber, this.stockParams.pageSize),
      this.httpClient);
  }

  getPrivateStocks(): Observable<PaginatedList<Stock>> {
    return getPagination<Stock>(
      this.baseUrl + "api/stockfeed/all-private",
      getPaginationHeaders(this.stockParams.pageNumber, this.stockParams.pageSize),
      this.httpClient);
  }

  setStockParams(stockParams: StockParams): void {
    this.stockParams = stockParams;
  }

  getStockParams(): StockParams {
    return this.stockParams;
  }
}
