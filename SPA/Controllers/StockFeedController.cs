using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPA.Data;
using SPA.Models.Dtos;
using SPA.Models.Entities;

namespace SPA.Controllers
{
    public class StockFeedController : ApiBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public StockFeedController(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
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

            return Ok(stocks);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all-private")]
        public async Task<ActionResult<IEnumerable<StockDto>>> GetAllPrivateStocksAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var stocks = await _context.Stocks
                .Include(s => s.User)
                .Where(s => s.User == user)
                .ProjectTo<StockDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(stocks);
        }
    }
}