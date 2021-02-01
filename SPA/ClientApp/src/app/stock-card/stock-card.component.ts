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
  }

}
