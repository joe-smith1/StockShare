using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SPA.Interfaces;
using SPA.Models.Dtos;

namespace SPA.Services
{
    /// <summary>
    /// <inheritdoc cref="ITradierService"/>
    /// <br/>
    /// <br/>
    /// Currently the only implemented methods are to get the quotes for the provided stocks
    /// and updated their CurrentValue from the APIs response with the latest stock price.
    /// </summary>
    public class TradierService : ITradierService
    {

        // Properties from dependency injection

        /// <summary>
        /// HTTP Factory used for creating HTTP contexts for our requests while not exhausting
        /// sockets.
        /// </summary>
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// Configuration of the application to get the Tradier Key from our environment.
        /// </summary>
        private readonly IConfiguration _config;

        public TradierService(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        /// <inheritdoc/>
        public async Task GetQuotes(IEnumerable<StockDto> stocks)
        {
            // No stocks to return so can't update their properties.
            if (stocks.IsNullOrEmpty())
            {
                return;
            }

            // Building the query string of symbols from the stocks to get quotes for.
            StringBuilder symbols = new StringBuilder();
            foreach (var stock in stocks)
            {
                symbols.Append(stock.Symbol);
                symbols.Append(',');
            }

            // Removing the trailing comma.
            symbols.Remove(symbols.Length - 1, 1);


            // Creating Client for tradier request along with headers for authentication and media type of JSON.
            var httpClient = _httpClientFactory.CreateClient("tradierGetQuote");
            httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _config["Tradier:AccessToken"]);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            var jsonRoot = JsonConvert.DeserializeObject<Root>(await httpClient.GetStringAsync(
                $"https://sandbox.tradier.com/v1/markets/quotes?symbols={symbols}&greeks=false"));


            var quotes = jsonRoot?.Quotes;

            if (quotes?.Quote == null)
            {
                return;
            }

            foreach (var quote in quotes.Quote)
            {
                // Our Linq select statement doesn't create a new object only updates the existing objects CurrentValue property
                // so no need to store the result as it uses a pointer to the same object in our stocks list.
                stocks.Where(s => s.Symbol == quote.Symbol)
                    .Select(s => s.CurrentValue = quote.Last).ToList();     // ToList is required to execute the LINQ statement.
            }
        }
    }
}