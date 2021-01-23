import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl} from '@angular/forms';

@Component({
  selector: 'app-add-stock',
  templateUrl: './add-stock.component.html',
  styleUrls: ['./add-stock.component.css']
})
export class AddStockComponent implements OnInit {
  stockAddForm: FormGroup;
  error: boolean = false;
  added: boolean = false;

  constructor(private http: HttpClient, @Inject("BASE_URL") private baseUrl: string,
    private fb: FormBuilder) { }

  ngOnInit() {
    this.stockAddForm = this.fb.group({
      Ticker: ["", Validators.required],
      Shares: ["", Validators.required],
      PurchaseDate: [""],
      ValueAtPurchase: [],
      ExchangeMarket: []
    })
  }

  addStock() {
    this.http.post(this.baseUrl + "api/stockupdate/add-stock", this.stockAddForm.value)
      .subscribe(result => {
        this.added = true;
      }, error => {
        this.error = true;
      })
  }

}
