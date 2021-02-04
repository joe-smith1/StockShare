using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SPA.Models.Dtos;

namespace SPA.Services
{
    public class TradierService : ITradierService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public TradierService(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        /// <inheritdoc/>
        public async Task GetQuotes(IEnumerable<StockDto> stocks)
        {
            StringBuilder tickers = new StringBuilder();
            foreach (var stock in stocks)
            {
                tickers.Append(stock.Ticker);
                tickers.Append(',');
            }

            using var httpClient = _httpClientFactory.CreateClient("tradierGetQuote");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config["Tradier:AccessToken"]);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var quotes = (await JsonSerializer.DeserializeAsync<Root>(await httpClient.GetStreamAsync(
                $"https://sandbox.tradier.com/v1/markets/quotes?symbols={tickers}&greeks=false")))?.Quotes;

            if (quotes == null)
            {
                return;
            }

            foreach (var quote in quotes.Quote)
            {
                // Our Linq select statement doesn't create a new object only updates the existing objects property
                // so no need to store the result as it uses a pointer to the same object in our stocks list.
                stocks.Where(s => s.Ticker == quote.Symbol)
                    .Select(s => s.CurrentValue = quote.Last).ToList();     // ToList is required to execute the LINQ statement.
            }
        }
    }
}