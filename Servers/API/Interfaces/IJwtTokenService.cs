using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Interfaces
{
    /// <summary>
    /// Interface for the JwtTokenService provides the methods related to
    /// the building of a Jwt token for authentication.
    /// </summary>
    public interface IJwtTokenService
    {
        /// <summary>
        /// Creates a Jwt Token for the provided user adding in their claims e.g roles
        /// and username as well as securing it with a symmetric security key for signing.
        /// </summary>
        /// <param name="user">The user to create a token for uses their properties like userName</param>
        /// <returns>The created JWT token as a string.</returns>
        Task<string> CreateTokenAsync(ApplicationUser user);
    }
}