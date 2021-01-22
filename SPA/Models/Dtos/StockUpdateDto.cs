using System;
using System.ComponentModel.DataAnnotations;

namespace SPA.Models.Dtos
{
    /// <summary>
    /// Dto used for updating a stock entity through a PUT request.
    /// </summary>
    public class StockUpdateDto
    {
        /// <summary>
        /// Id used to identify the related entity in our database.
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// The Ticker of the stock e.g TSLA.
        /// </summary>
        public string Ticker { get; set; }

        /// <summary>
        /// The number of shares bought for this stock.
        /// </summary>

        public decimal Shares { get; set; }

        /// <summary>
        /// The Date that this stock was purchased.
        /// </summary>
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// The value of a single share of this stock at the purchase date.
        /// </summary>
        public decimal ValueAtPurchase { get; set; } // TODO Set ValueAtPurchase based off purchase Date using finance api instead of passing it in.

        /// <summary>
        /// The Exchange Market of this stock e.g what market it is traded on.
        /// </summary>
        public string ExchangeMarket { get; set; }
    }
}