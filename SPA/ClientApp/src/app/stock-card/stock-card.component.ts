import { Component, OnInit, Input } from '@angular/core';
import { Stock } from '../_models/Stock';

@Component({
  selector: 'app-stock-card',
  templateUrl: './stock-card.component.html',
  styleUrls: ['./stock-card.component.css']
})
export class StockCardComponent implements OnInit {
  @Input() stock: Stock;

  constructor() {
  }

  ngOnInit(): void {
    debugger;
    // Initializing the purchaseDate property as it might not have been properly casted to Date when getting from api.
    this.stock.purchaseDate = new Date(this.stock.purchaseDate);
  }

}
