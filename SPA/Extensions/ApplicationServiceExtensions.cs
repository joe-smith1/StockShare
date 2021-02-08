using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SPA.Data;
using SPA.Helpers;
using SPA.Services;
using SPA.Interfaces;

namespace SPA.Extensions
{
    /// <summary>
    /// Extension class provides extension methods for setting up the different Services in the application.
    /// </summary>
    public static class ApplicationServiceExtensions
    {
        /// <summary>
        /// This extension provides a clean way to add all our specified services for the application here
        /// rather that in the ConfigureServices method of Startup.
        /// </summary>
        /// <param name="services">Service collection from ConfigureServices to add new Services to.</param>
        /// <param name="config">Application Configuration settings to get our db connection string.</param>
        /// <returns><paramref name="services"/> with the newly added services.</returns>
        public static IServiceCollection AddCustomServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(config.GetConnectionString("DefaultConnection")));

            // Adding our auto mapper profiles as a service so can later use them through dependency injection.
            services.AddAutoMapper(typeof(AutoMapperOrganizationProfile));

            // Adding HttpClient so we can inject IHttpClientFactory throughout our application preventing socket exhaustion.
            services.AddHttpClient();

            // Adding our TradierService for dependency injection through our application scoped to the current http request.
            services.AddScoped<ITradierService, TradierService>();

            return services;
        }
    }
}