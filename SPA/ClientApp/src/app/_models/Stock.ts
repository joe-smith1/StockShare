export interface Stock {
  id: string,

  symbol: string,

  shares: number,

  purchaseDate: Date,

  valueAtPurchase: number,

  currentValue: number,

  exchangeMarket: string,

  dailyGainLoss?: number,

  weeklyGainLoss?: number,

  monthlyGainLoss?: number,

  yearlyGainLoss?: number
}
