using System.Collections;
using System.Collections.Generic;
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


        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<StockDto>>> GetAllStocksAsync()
        {
            var stocks = await _context.Stocks
                .ProjectTo<StockDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return Ok(stocks);
        }
    }
}