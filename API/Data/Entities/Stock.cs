using System;

namespace API.Data.Entities
{
    /// <summary>
    /// Entity represents a stock that is related to a User.
    /// Aka we have a many to one relationship from stocks to user.
    /// Stores properties related to the stock e.g amount of shares and
    /// purchase date.
    /// </summary>
    public class Stock
    {
        public int Id { get; set; }

        /// <summary>
        /// The Ticker of the stock e.g TSLA
        /// </summary>
        public string Ticker { get; set; }

        public int Shares { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal ValueAtPurchase { get; set; }
        public decimal CurrentValue { get; set; }

        // Nullable Properties.
        public string? ExchangeMarket { get; set; }
        public decimal? DailyGainLoss { get; set; }
        public decimal? WeeklyGainLoss { get; set; }
        public decimal? MonthlyGainLoss { get; set; }
        public decimal? YearlyGainLoss { get; set; }

        // Navigational relationships.
        public virtual ApplicationUser User { get; set; }
    }
}