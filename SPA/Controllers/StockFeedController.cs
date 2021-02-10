using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPA.Data;
using SPA.Helpers;
using SPA.Models.Dtos;
using SPA.Models.Entities;
using SPA.Interfaces;
using SPA.Models.Dtos.Filters;
using SPA.Models.Wrappers;

namespace SPA.Controllers
{
    /// <summary>
    /// This Controller provides the actions for the requests to get stocks in a feed style
    /// we will later add pagination and filtering to these actions but currently they return
    /// all items. You can either get all public stocks or just those of the currently authenticated
    /// user.
    /// </summary>
    public class StockFeedController : ApiBaseController
    {

        // Readonly properties through dependency injection.

        /// <summary>
        /// Database context for our application allows us to get
        /// entities to modify through it.
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Mapper used for auto mapper configurations e.g from
        /// Stock entity to DTO.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// User manager allows us to get the currently authenticated user.
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// This service allows us to make an api request to update the
        /// properties of our stocks to return with valid financial
        /// information.
        /// </summary>
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
        /// <remarks>Currently the Tradier service updates the current price of each
        /// valid stockDto to be returned.</remarks>
        [HttpGet]
        [Route("all-public")]
        public async Task<ActionResult<IEnumerable<StockDto>>> GetAllPublicStocksAsync([FromQuery] PaginationFilter paginationFilter)
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
        /// <remarks>Currently the Tradier service updates the current price of each
        /// valid stockDto to be returned.</remarks>
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