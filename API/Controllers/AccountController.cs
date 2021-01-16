using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Data.Dtos;
using API.Data.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    /// <summary>
    /// Account controller provides actions related to the user account state e.g logging in.
    /// the provided actions are registration and logging in where we also provide the client
    /// that receives the actions response with a JWT bearer token to authenticate them later.
    /// </summary>
    public class AccountController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IJwtTokenService _jwtTokenService;

        /// <summary>
        /// Manager used with identity for creating users, deleting them and checking if they exist.
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        /// <summary>
        /// Used with the login action to sign in users this will handle password hashing etc.
        /// </summary>
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IMapper mapper, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _jwtTokenService = jwtTokenService;
        }

        /// <summary>
        /// Action to register a newly created user, we take in a RegisterDto with the properties provided for a new user creation
        /// then attempt to register this user through the user manager identity will provide us with any errors that caused the
        /// user not to be added e.g user name is already taken. Finally the user is returned with route as an AuthenticatedUserDto
        /// if created.
        /// </summary>
        /// <param name="registerDto">Verified registration properties through the RegisterDto from the POST request.</param>
        /// <returns>The mapped AuthenticatedUserDto from the user with minimal required properties
        /// along with a JWT token for later authentication.</returns>
        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<AuthenticatedUserDto>> RegisterUser(RegisterDto registerDto)
        {
            // Mapping registerDto properties to a new ApplicationUser then creating this new user in our database through identity.
            var userToRegister = _mapper.Map<ApplicationUser>(registerDto);

            if (userToRegister == null)
            {
                return BadRequest("Failed to create user from provided details.");
            }

            var userCreationResult = await _userManager.CreateAsync(userToRegister, registerDto.Password);

            if (!userCreationResult.Succeeded)
            {
                // Returning all errors in an easy to read format e.g user name already taken or email.
                var errorsResponse = new StringBuilder();
                foreach (var error in userCreationResult.Errors)
                {
                    errorsResponse.Append("\n");
                    errorsResponse.Append(error.Description);
                }
                return BadRequest($"Failed to register for the following reasons: {errorsResponse}");
            }

            // Mapping to a AuthenticatedUserDto so we only send back the required properties.
            var loggedInUser = MapUserAndAddTokenAsync(userToRegister);

            // TODO add route of getting user (once this action and controller is created).
            return CreatedAtRoute("", loggedInUser);
        }

        /// <summary>
        /// Action to login a user with the provided username and password. The sign in manager through identity is then
        /// used to try to verify the password with the user found with the provided username in the database.
        /// </summary>
        /// <param name="loginDto">LoginDto that receives the validated properties sent up in the POST request</param>
        /// <returns>AuthenticatedUserDto with the created JSON token if login is valid
        /// otherwise Unauthorized response.</returns>
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<AuthenticatedUserDto>> Login(LoginDto loginDto)
        {
            const string unauthorizedResponse = "Invalid username or password!";

            var userToSignIn = await
                _userManager.Users.SingleOrDefaultAsync(u => u.UserName == loginDto.UserName);

            if (userToSignIn == null)
            {
                return Unauthorized(unauthorizedResponse);
            }

            var loginResult = await _signInManager.PasswordSignInAsync(userToSignIn, loginDto.Password, false, false);

            if (loginResult.Succeeded)
            {
                var loggedInUser = await MapUserAndAddTokenAsync(userToSignIn);
                return Ok(loggedInUser);
            }

            return Unauthorized(unauthorizedResponse);
        }

        /// <summary>
        /// Uses auto mapper to map the provided ApplicationUser to an AuthenticatedUserDto and adds a
        /// generated Jwt token for the given User onto the Dto which can then be used for authenticating
        /// other requests.
        /// </summary>
        /// <param name="user">The user to that's been authenticated and ready to be returned.</param>
        /// <returns>The Mapped user with the generated Jwt token.</returns>
        private async Task<AuthenticatedUserDto> MapUserAndAddTokenAsync(ApplicationUser user)
        {
            var loggedInUser = _mapper.Map<AuthenticatedUserDto>(user);
            loggedInUser.Token = await _jwtTokenService.CreateTokenAsync(user);
            return loggedInUser;
        }

    }
}