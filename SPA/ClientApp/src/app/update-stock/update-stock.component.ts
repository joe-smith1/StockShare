import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { StockService } from '../services/stock/stock.service';
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

  constructor(private fb: FormBuilder, private stockService: StockService) { }

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
    this.stockService.updateStock(<StockToUpdate>this.stockUpdateForm.value)
      .subscribe(response => {
        this.updated = true;
      }
        , error => {
        this.validationErrors = error;
      });
  }

}
