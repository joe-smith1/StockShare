import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { StockToAdd } from 'src/app/_models/StockToAdd';
import { StockToUpdate } from 'src/app/_models/StockToUpdate';

@Injectable({
  providedIn: 'root'
})
export class StockService {

  constructor(private http: HttpClient, @Inject("BASE_URL") private baseUrl: string) { }

  updateStock(stock: StockToUpdate): Observable<Object> {

    // Setting these number values to null if they are empty e.g empty string as otherwise we get a validation error
    // as the apis DTO to map to is expecting numbers but the form provides us with strings e.g in the case of
    // writing a number in the control then removing it returns '' which isn't mappable to decimal in our api.
    stock.shares = stock.shares ? stock.shares : null;
    stock.valueAtPurchase = stock.valueAtPurchase ? stock.valueAtPurchase : null;

    return this.http.put(this.baseUrl + 'api/stockupdate/update-stock', stock);
  }

  addStock(stock: StockToAdd) {
    return this.http.post(this.baseUrl + "api/stockupdate/add-stock", stock);
  }
}
