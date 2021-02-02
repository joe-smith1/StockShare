import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Stock } from 'src/app/_models/Stock';

@Injectable({
  providedIn: 'root'
})
export class StockFeedService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getPublicStocks(): Observable<Stock[]> {
    return this.httpClient.get<Stock[]>(this.baseUrl + 'api/stockfeed/all-public');
  }

  getPrivateStocks(): Observable<Stock[]> {
    return this.httpClient.get<Stock[]>(this.baseUrl + "api/stockfeed/all-private");
  }
}
