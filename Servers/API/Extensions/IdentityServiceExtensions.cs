using System;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    /// <summary>
    /// Extension class for adding all Identity and Authentication services along with JWT tokens.
    /// </summary>
    public static class IdentityServiceExtensions
    {
        /// <summary>
        /// Adds Identity core services to the application via this extension for a cleaner
        /// Startup class. Adds RoleManagers and SignInManager services to allow later user
        /// throughout the application. Also sets up specific identity properties.
        /// </summary>
        /// <param name="services">Service collection to add the identity services too.</param>
        /// <returns><paramref name="services"/> with the added identity services.</returns>
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    // Lockout for 15 minutes when lockout is applied aka 5 failed attempts.
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

                    // SET TO TRUE WHEN SETTING UP REQUIRED ACCOUNTS.
                    //options.SignIn.RequireConfirmedAccount = true;
                    options.User.RequireUniqueEmail = true;
                })
                .AddRoleManager<RoleManager<ApplicationRole>>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddRoleValidator<RoleValidator<ApplicationRole>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // TODO LOOK INTO MORE ADVANCED AUTHENTICATION e.g with OPEN ID CONNECT using AZURE AD.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    //options.Authority = "";
                    //options.Audience = "";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //ClockSkew = TimeSpan.FromMinutes(5),

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtTokenKey"])),
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false


                        //RequireSignedTokens = true,

                        //RequireExpirationTime = true,
                        //ValidateLifetime = true,

                        //ValidateAudience = true,
                        //ValidAudience = "",

                        //ValidateIssuer = true,
                        //ValidIssuer = ""

                    };
                });

            services.AddAuthorization();
            return services;
        }
    }
}