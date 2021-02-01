import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { StockToUpdate } from '../_models/StockToUpdate';

@Component({
  selector: 'app-update-stock',
  templateUrl: './update-stock.component.html',
  styleUrls: ['./update-stock.component.css']
})
export class UpdateStockComponent implements OnInit {
  stockUpdateForm: FormGroup;
  validationErrors: string[] = [];
  updated: boolean = false;
  maxDate: Date;
  constructor(private http: HttpClient, private fb: FormBuilder, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit(): void {
    this.stockUpdateForm = this.fb.group({
        id: ['', [Validators.required]],
        ticker: [''],
        shares: [],
        purchaseDate: [],
        valueAtPurchase: [],
        exchangeMarket: ['']
    });

    this.maxDate = new Date();
    this.maxDate.setDate(this.maxDate.getDate());
  }

  // TODO Will need to change this in the future so that a stock object is passed in
  // as we cant expect the user to remember the guid of the stock.
  updateStock() {
    let stockToUpdate = <StockToUpdate>this.stockUpdateForm.value;

    // Setting these number values to null if they are empty e.g empty string as otherwise we get a validation error
    // as the apis DTO to map to is expecting numbers but the form provides us with strings e.g in the case of
    // writing a number in the control then removing it returns '' which isn't mappable to decimal in our api.
    stockToUpdate.shares = stockToUpdate.shares ? stockToUpdate.shares : null;
    stockToUpdate.valueAtPurchase = stockToUpdate.valueAtPurchase ? stockToUpdate.valueAtPurchase : null;

    this.http.put(this.baseUrl + 'api/stockupdate/update-stock', stockToUpdate)
      .subscribe(response => {
        this.updated = true;
      }
        , error => {
        this.validationErrors = error;
      });
  }

}
