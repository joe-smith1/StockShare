using System;
using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos
{
    /// <summary>
    /// Dto used for the creation of a stock through a POST request e.g when
    /// the client makes a POST request to create a stock the body of that request
    /// is mapped into this DTO.
    /// </summary>
    public class StockCreationDto
    {

        /// <summary>
        /// The Ticker of the stock e.g TSLA.
        /// Is a required property.
        /// </summary>
        [Required]
        public string Ticker { get; set; }
        /// <summary>
        /// The number of shares bought for this stock.
        /// Is a required property.
        /// </summary>
        [Required]
        public uint Shares { get; set; }

        /// <summary>
        /// The Date that this stock was purchased.
        /// If no value is provided the stock purchase date defaults to now in the Stock entity.
        /// </summary>
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// The value of a single share of this stock at the purchase date.
        /// </summary>
        public decimal ValueAtPurchase { get; set; } // TODO Set ValueAtPurchase based off purchase Date using finance api instead of passing it in.
    }
}