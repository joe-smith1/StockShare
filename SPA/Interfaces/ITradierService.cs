using System.Collections.Generic;
using System.Threading.Tasks;
using SPA.Models.Dtos;

namespace SPA.Interfaces
{
    /// <summary>
    /// This Service provides methods to make requests to the Tradier API.
    /// For example getting the quotes of a list of stocks and updating their current values
    /// from the provided response. Each method will handle deserializing the APIs response.
    /// </summary>
    public interface ITradierService
    {
        /// <summary>
        /// Gets quotes (all stock info) for the given stocks and updates the provided StockDtos current stock price if available.
        /// </summary>
        /// <param name="stocks">Collection of StockDtos to have their current price properties updated.</param>
        Task GetQuotes(IEnumerable<StockDto> stocks);
    }
}