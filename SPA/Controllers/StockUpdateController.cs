using System.Threading.Tasks;
using SPA.Data;
using AutoMapper;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPA.Models.Dtos;
using SPA.Models.Entities;

namespace SPA.Controllers
{
    /// <summary>
    /// This controller contains the actions that can be performed to update a stock,
    /// this includes adding a new stock or updating an existing stocks properties.
    /// </summary>
    public class StockUpdateController : ApiBaseController
    {
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// Mapper used to map from entities to dtos and back.
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// User manager used to get the current user making the request based off their claims.
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;

        public StockUpdateController(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        /// <summary>
        /// This action creates a stock entity based off the StockCreationDto passed in
        /// and adds it to the user making this request creating a relation in our database.
        /// </summary>
        /// <param name="stockCreationDto">The StockCreationDto created from the body of this POST request.</param>
        /// <returns>A StockDto of the created stock entity otherwise a 4xx response.</returns>
        [Route("add-stock")]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<StockDto>> AddStockAsync(StockCreationDto stockCreationDto)
        {

            // TODO BUG HERE RETURNS NULL
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

        [HttpPut]
        [Route("update-stock")]
        [Authorize]
        public async Task<ActionResult> UpdateStockAsync(StockUpdateDto stockUpdateDto)
        {
            var stock = await _context.Stocks
                .SingleOrDefaultAsync(s => s.Id == stockUpdateDto.Id);

            if (stock == null)
            {
                return BadRequest($"A stock with the id provided ({stockUpdateDto.Id}) does not exist!");
            }

            stock = _mapper.Map(stockUpdateDto, stock);

            return Ok();
        }
    }
}