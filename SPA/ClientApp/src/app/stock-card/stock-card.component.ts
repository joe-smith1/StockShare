import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Inject } from '@angular/core';
import { inject } from '@angular/core/testing';

@Component({
  selector: 'app-stock-card',
  templateUrl: './stock-card.component.html',
  styleUrls: ['./stock-card.component.css']
})
export class StockCardComponent implements OnInit {

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {

  }

  ngOnInit(): void {
  }

}
