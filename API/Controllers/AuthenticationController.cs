using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Data.Dtos;
using API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AuthenticationController : ApiBaseController
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<AuthenticatedUserDto>> RegisterUser(RegisterDto registerDto)
        {
            /* TODO Check user with given username doesnt already exist (email should be unique so identiy should prevent this (DOUBLE CHECK))
               map the RegisterDto to the ApplicationUser then use user manager to create a user then sign them in and return
               as a AuthenticatedUserDto thats been mapped from the user and (provided the token too) this bit can be done later.*/

        }
    }
}