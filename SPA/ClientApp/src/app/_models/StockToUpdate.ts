export interface StockToUpdate {
  Id: string,
  Ticker: string,
  Shares: number | string,
  PurchaseDate: Date,
  ValueAtPurchase: number | string,
  ExchangeMarket: string
}
