using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace API.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        /// <summary>
        /// User manager needed for getting the roles of a user to add into the claims in jwt payload.
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Symmetric key using a secret value stored in our environment for the signing of the token.
        /// </summary>
        private readonly SymmetricSecurityKey _jwtKey;

        public JwtTokenService(IConfiguration config, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtTokenKey"]));
        }

        public async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var jwtClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);

            // Adding all the roles of the user projected as claims to go in the token.
            jwtClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            // Using our symmetric security key in signing credentials to later provide a signed token that we will know if its been modified.
            var jwtCredentials = new SigningCredentials(_jwtKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(jwtClaims),
                Expires = DateTime.Now.AddHours(4),
                SigningCredentials = jwtCredentials
            };

            // Creating the token then returning it serialized as a string.
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateToken(tokenDescriptor);

            return jwtTokenHandler.WriteToken(jwtToken);
        }
    }
}