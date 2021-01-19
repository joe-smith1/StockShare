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
        /// Is a required property of the entity.
        /// </summary>
        public string Ticker { get; set; }
        /// <summary>
        /// The number of shares of this stock that were purchased.
        /// </summary>
        public uint Shares { get; set; }
        /// <summary>
        /// The Date of the stock purchase a time can also be provided.
        /// This DateTime could be used for calling an api to get the
        /// value at purchase.
        /// </summary>
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// Date that the entity was created for our database this
        /// could be used for sorting our feed.
        /// </summary>
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// The Value of a single share at the time of purchase.
        /// This can be provided by the user or gotten via an external api call.
        /// </summary>
        public decimal ValueAtPurchase { get; set; }
        /// <summary>
        /// The current value of a signle share of this stock.
        /// </summary>
        public decimal CurrentValue { get; set; }

        // Nullable properties.

        /// <summary>
        /// The Exchange Market of this stock e.g what market it is traded on.
        /// This property can be null in our database.
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


        // Navigational relationships.
        /// <summary>
        /// Relation to the User that owns this stock.
        /// Will be a foreign key in the database.
        /// </summary>
        public virtual ApplicationUser User { get; set; }
    }
}