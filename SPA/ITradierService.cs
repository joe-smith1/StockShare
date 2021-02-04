using System.Collections.Generic;
using System.Threading.Tasks;
using SPA.Models.Dtos;

namespace SPA
{
    public interface ITradierService
    {
        /// <summary>
        /// Gets quotes (all stock info) for the given stocks, we append all the ticker names onto the query string to get
        /// all the quotes.
        /// </summary>
        /// <param name="stocks">Collection of StockDtos that will be returned to the user so need to update price values.</param>
        /// <returns>Currently only returns the JSON string of all quotes.</returns>
        Task GetQuotes(IEnumerable<StockDto> stocks);
    }
}