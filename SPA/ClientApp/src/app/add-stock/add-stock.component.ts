import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, ValidatorFn, AbstractControl} from '@angular/forms';
import { StockToAdd } from '../_models/StockToAdd';

@Component({
  selector: 'app-add-stock',
  templateUrl: './add-stock.component.html',
  styleUrls: ['./add-stock.component.css']
})
export class AddStockComponent implements OnInit {
  stockAddForm: FormGroup;
  error: boolean = false;
  added: boolean = false;
  maxDate: Date;
  validationErrors: string[] = [];

  constructor(private http: HttpClient, @Inject("BASE_URL") private baseUrl: string,
    private fb: FormBuilder) { }

  ngOnInit() {
    this.stockAddForm = this.fb.group({
      Ticker: ['', Validators.required],
      Shares: [, [Validators.required]],
      PurchaseDate: [],
      ValueAtPurchase: [, [Validators.required]],
      ExchangeMarket: ['']
    })

    this.maxDate = new Date();
    this.maxDate.setDate(this.maxDate.getDate());
  }

  addStock(): void {
    this.http.post(this.baseUrl + "api/stockupdate/add-stock", <StockToAdd>this.stockAddForm.value)
      .subscribe(result => {
        this.added = true;
      }, error => {
        this.validationErrors = error;
      })
  }
}
