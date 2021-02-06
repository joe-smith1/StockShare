using System;
using System.ComponentModel.DataAnnotations;

namespace SPA.Models.Dtos
{
    /// <summary>
    /// Dto used for the creation of a stock through a POST request e.g when
    /// the client makes a POST request to create a stock the body of that request
    /// is mapped into this DTO.
    /// </summary>
    public class StockCreationDto
    {

        /// <summary>
        /// The Symbol of the stock e.g TSLA.
        /// Is a required property.
        /// </summary>
        [Required]
        public string Symbol { get; set; }

        /// <summary>
        /// The number of shares bought for this stock.
        /// Is a required property.
        /// </summary>
        [Required]
        public decimal Shares { get; set; }


        /// <summary>
        /// The value of a single share of this stock at the purchase date.
        /// Is a required property.
        /// </summary>
        [Required] // TODO CURRENTLY REQUIRED BUT IN FUTURE TRY  Set ValueAtPurchase based off purchase Date using finance api instead of passing it in.
        public decimal ValueAtPurchase { get; set; }

        /// <summary>
        /// The Date that this stock was purchased.
        /// If no value is provided the stock purchase date defaults to utc now in the Stock entity.
        /// </summary>
        public DateTime? PurchaseDate { get; set; }

        /// <summary>
        /// The Exchange Market of this stock e.g what market it is traded on.
        /// </summary>
        public string ExchangeMarket { get; set; }
    }
}