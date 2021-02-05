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
using Newtonsoft.Json.Linq;
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
            if (stocks.IsNullOrEmpty())
            {
                return;
            }

            StringBuilder tickers = new StringBuilder();
            foreach (var stock in stocks)
            {
                tickers.Append(stock.Ticker);
                tickers.Append(',');
            }

            // Removing the trailing comma;
            tickers.Remove(tickers.Length - 1, 1);

            using var httpClient = _httpClientFactory.CreateClient("tradierGetQuote");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config["Tradier:AccessToken"]);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringRep = await httpClient.GetStringAsync(
                $"https://sandbox.tradier.com/v1/markets/quotes?symbols={tickers}&greeks=false");
            Console.WriteLine(stringRep);

            var jsonRoot = JsonConvert.DeserializeObject<Root>(await httpClient.GetStringAsync(
                $"https://sandbox.tradier.com/v1/markets/quotes?symbols={tickers}&greeks=false"));

            var quotes = jsonRoot?.Quotes;

            if (quotes == null || quotes.Quote == null)
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