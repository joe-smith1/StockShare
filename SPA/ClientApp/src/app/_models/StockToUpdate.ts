export interface StockToUpdate {
  id: string,
  ticker: string,
  shares: number | string,
  purchaseDate: Date,
  valueAtPurchase: number | string,
  exchangeMarket: string
}
