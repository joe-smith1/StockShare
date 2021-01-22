﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SPA.Data;
using SPA.Models.Entities;

namespace SPA.Extensions
{
    /// <summary>
    /// Extension class for adding all Identity and Authentication services.
    /// </summary>
    public static class IdentityServiceExtensions
    {
        /// <summary>
        /// Adds Identity services to the application via this extension for a cleaner
        /// Startup class. Adds RoleManagers and SignInManager services to allow later user
        /// throughout the application. Also sets up specific identity properties.
        /// </summary>
        /// <param name="services">Service collection to add the identity services too.</param>
        /// <returns><paramref name="services"/> with the added identity services.</returns>
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    // Lockout for 15 minutes when lockout is applied aka 5 failed attempts.
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                    options.SignIn.RequireConfirmedAccount = true;
                    options.User.RequireUniqueEmail = true;
                })
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddUserManager<UserManager<ApplicationUser>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            // Configures app to validate JWT tokens issued by IdentityServer for this application.
            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.Configure<JwtBearerOptions>(
                IdentityServerJwtConstants.IdentityServerJwtBearerScheme, options =>
                {
                    var onTokenValidated = options.Events.OnTokenValidated;

                    // Event handler custom implementation would run original implementation aka onTokenValidated then runs its custom logic.
                    options.Events.OnTokenValidated = async context =>
                    {
                        await onTokenValidated(context);
                        // Custom Logic would go here ...
                    };
                });


            return services;
        }
    }
}