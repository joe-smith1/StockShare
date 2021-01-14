using System;
using API.Data;
using API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

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
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
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

            // TODO JWT services Authentication setup.
            return services;
        }
    }
}