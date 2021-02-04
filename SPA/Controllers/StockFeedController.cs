using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
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
        private readonly ITradierService _tradierService;


        public StockFeedController(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, ITradierService tradierService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _tradierService = tradierService;
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
            await _tradierService.GetQuotes(stocks);
            return Ok(stocks);
        }

        /// <summary>
        /// Gets all the stocks for the currently logged in user.
        /// </summary>
        /// <returns>A Enumerable collection of the users Stocks as StockDtos.</returns>
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
            await _tradierService.GetQuotes(stocks);
            return Ok(stocks);
        }
    }
}