using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPA.Data;
using SPA.Extensions;
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
        /// Gets the public stocks from our Stocks table in the database for the given page and size.
        /// A public stock is a stock who's User that created it is public.
        /// </summary>
        /// <param name="paginationFilter">
        /// Pagination details for the current page and the size of the page aka how many stocks to return.
        /// </param>
        /// <returns>A <see cref="PagedList{T}"/> of the public stocks for the requested page projected to <see cref="StockDto"/>.</returns>
        [HttpGet]
        [Route("all-public")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<PagedList<StockDto>>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedList<StockDto>))]
        public async Task<ActionResult<PagedResponse<PagedList<StockDto>>>> GetAllPublicStocksAsync([FromQuery] PaginationFilter paginationFilter)
        {
            var stocksQuery = _context.Stocks
                .Include(s => s.User)
                .Where(s => !s.User.PrivateAccount)
                .ProjectTo<StockDto>(_mapper.ConfigurationProvider);

            return await ProcessFeed(stocksQuery, paginationFilter);
        }

        /// <summary>
        /// Gets the current logged in users stocks from the database for the given page and size.
        /// </summary>
        /// <param name="paginationFilter">
        /// Pagination details for the current page and the size of the page aka how many stocks to return.
        /// </param>
        /// <returns>A <see cref="PagedList{T}"/> of the users Stocks as <see cref="StockDto"/>.</returns>
        [HttpGet]
        [Route("all-private")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<PagedList<StockDto>>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedList<StockDto>))]
        public async Task<ActionResult<PagedResponse<PagedList<StockDto>>>> GetAllPrivateStocksAsync([FromQuery] PaginationFilter paginationFilter)
        {
            var user = await _userManager.GetUserAsync(User);
            var stocksQuery = _context.Stocks
                .Include(s => s.User)
                .Where(s => s.User == user)
                .ProjectTo<StockDto>(_mapper.ConfigurationProvider);

            return await ProcessFeed(stocksQuery, paginationFilter);
        }


        /// <summary>
        /// Paginates the provided stock query executing it to get the required entities(projected to <see cref="StockDto"/>) for the page
        /// from the database. The pagination parameters are then added to the headers of the Response for the executing action.
        /// Finally the stocks to return are updated through the tradier service and then returned via their return type specified through
        /// <paramref name="paginationFilter"/>.
        /// </summary>
        /// <param name="stocksQuery">The query of <see cref="StockDto"/> to be paginated and returned e.g all public stocks.</param>
        /// <param name="paginationFilter">
        /// The <see cref="PaginationFilter"/> from the controllers executing action these are the query string details related
        /// to the pagination part of the request specifying the size and page number of the page to get as well as how to return it.
        /// </param>
        /// <returns>
        /// Either returns a <see cref="PagedList{T}"/> of <see cref="StockDto"/> by itself if the
        /// <paramref name="paginationFilter"/> doesn't specify to wrap the pagination, in the case that the client wants to
        /// wrap the response then a <see cref="PagedResponse{T}"/> is returned wrapping the list to provide these additional properties.
        /// </returns>
        private async Task<ActionResult<PagedResponse<PagedList<StockDto>>>> ProcessFeed(IQueryable<StockDto> stocksQuery,
            PaginationFilter paginationFilter)
        {
            var stockList = await PagedList<StockDto>.CreateAsync(stocksQuery, paginationFilter.PageNumber, paginationFilter.PageSize);

            Response.AddPaginationHeaders(stockList);

            // Updating the CurrentValue of the stocks to be returned with live prices.
            await _tradierService.GetQuotes(stockList);

            if (!paginationFilter.PaginationWrapper)
            {
                return Ok(stockList);
            }

            return Ok(new PagedResponse<PagedList<StockDto>>(stockList));
        }
    }
}