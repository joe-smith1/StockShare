using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SPA.Data;
using SPA.Models.Dtos;
using SPA.Models.Entities;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace SPA.Controllers
{
    public class StockFeedController : ApiBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public StockFeedController(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
            _config = config;
        }


        /// <summary>
        /// Gets all the public stocks from our Stocks table in the database.
        /// A public stock is a stock who's User that created it is public.
        /// </summary>
        /// <returns>A Enumerable collection of all public stocks projected to StockDtos.</returns>
        [HttpGet]
        [Route("all-public")]
        public async Task<ActionResult<IEnumerable<StockDto>>> GetAllPublicStocksAsync()
        {
            var stocks = await _context.Stocks
                .Include(s => s.User)
                .Where(s => !s.User.PrivateAccount)
                .ProjectTo<StockDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            await GetQuotes(stocks);
            return Ok(stocks);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all-private")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<StockDto>>> GetAllPrivateStocksAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var stocks = await _context.Stocks
                .Include(s => s.User)
                .Where(s => s.User == user)
                .ProjectTo<StockDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            await GetQuotes(stocks);
            return Ok(stocks);
        }




        // TODO create a service for all the actions from tradier.
        /// <summary>
        /// Gets quotes (all stock info) for the given stocks, we append all the ticker names onto the query string to get
        /// all the quotes.
        /// </summary>
        /// <param name="stocks">Collection of StockDtos that will be returned to the user so need to update price values.</param>
        /// <returns>Currently only returns the JSON string of all quotes.</returns>
        private async Task GetQuotes(IEnumerable<StockDto> stocks)
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

            var stringResponce = await httpClient.GetStringAsync(
                $"https://sandbox.tradier.com/v1/markets/quotes?symbols={tickers}&greeks=false");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(stringResponce);
            Console.ResetColor();
        }
    }
}