import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { StockCreation } from '../_models/StockCreation';

@Component({
  selector: 'app-add-stock',
  templateUrl: './add-stock.component.html',
  styleUrls: ['./add-stock.component.css']
})
export class AddStockComponent implements OnInit {
  @ViewChild('stockAddForm') stockAddForm: NgForm;

  stockToAdd: StockCreation;
  error: boolean = false;
  added: boolean = false;

  constructor(private http: HttpClient, @Inject("BASE_URL") private baseUrl: string) { }

  ngOnInit() {
    // USING AS A CHEAP WAY TO GET OVER ERRORS WILL NEED TO CHANGE FORM TYPE.
    this.stockToAdd = {
      Ticker: 'TSLA',
      Shares: 55,
      PurchaseDate: Date.now.toString(),
      ValueAtPurchase: 840.55,
      ExchangeMarket: 'NYSE'
    };
  }

  addStock() {
    this.http.post(this.baseUrl + "api/stockupdate/add-stock", this.stockToAdd)
      .subscribe(result => {
        this.added = true;
      }, error => {
        this.error = true;
      })
  }

}
