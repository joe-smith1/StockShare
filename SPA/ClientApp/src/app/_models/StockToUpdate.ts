export interface StockToUpdate {
  id: string,
  symbol: string,
  shares: number | string,
  purchaseDate: Date,
  valueAtPurchase: number | string,
  exchangeMarket: string
}
