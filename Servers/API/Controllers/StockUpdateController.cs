using System.Threading.Tasks;
using API.Data;
using API.Data.Dtos;
using API.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StockUpdateController : ApiBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public StockUpdateController(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        [Route("add-stock")]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddStockAsync(StockCreationDto stockCreationDto)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized("User could not be found!");
            }

            var stock = _mapper.Map<Stock>(stockCreationDto);

            if (stock == null)
            {
                return BadRequest("Stock could not be created!");
            }

            user.Stocks.Add(stock);

            await _context.SaveChangesAsync();

            var stockDto = _mapper.Map<StockDto>(stock);
            return CreatedAtRoute("", stockDto);    // ADD THE ACTION ROUTE NAME ONCE CREATED TO GET AN INDIVIDUAL STOCK.
        }
    }
}