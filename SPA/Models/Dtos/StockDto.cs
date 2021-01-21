using System;

namespace SPA.Models.Dtos
{
    /// <summary>
    /// Stock Dto is used to return the properties of a Stock entity that the user should see.
    /// </summary>
    public class StockDto
    {
        /// <summary>
        /// The Ticker of the stock e.g TSLA.
        /// </summary>
        public string Ticker { get; set; }
        /// <summary>
        /// Number of shares of this stock that were purchased.
        /// </summary>
        public decimal Shares { get; set; }
        /// <summary>
        /// The date and time that the purchase of this stock was made.
        /// </summary>
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// The value of a single share at the time of purchase.
        /// </summary>
        public decimal ValueAtPurchase { get; set; }
        /// <summary>
        /// The current market value of a single share.
        /// </summary>
        public decimal CurrentValue { get; set; }

        // Values that could be null.

        /// <summary>
        /// The market that this stock is traded on.
        /// </summary>
        public string ExchangeMarket { get; set; }
        /// <summary>
        /// The current value of this stock compared to the previous days closing value.
        /// </summary>
        public decimal? DailyGainLoss { get; set; }
        /// <summary>
        /// The current value of this stock compared to the previous weeks closing value aka 7 days ago.
        /// </summary>
        public decimal? WeeklyGainLoss { get; set; }
        /// <summary>
        /// The current value of this stock compared to a month agos closing value.
        /// </summary>
        public decimal? MonthlyGainLoss { get; set; }
        /// <summary>
        /// The current value of this stock compared to a year agos closing value.
        /// </summary>
        public decimal? YearlyGainLoss { get; set; }
    }
}