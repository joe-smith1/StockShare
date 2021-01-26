export interface StockToAdd {
  Ticker: string,
  Shares: number | string,
  PurchaseDate: Date,
  ValueAtPurchase: number | string,
  ExchangeMarket: string
}
