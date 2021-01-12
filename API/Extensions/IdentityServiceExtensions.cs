using API.Data;
using API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentityCore<ApplicationUser>(options =>
                {
                    // TODO Configure identity options here.
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddRoles<ApplicationRole>()
                .AddRoleValidator<RoleValidator<ApplicationRole>>()
                .AddRoleManager<RoleManager<ApplicationRole>>()
                .AddSignInManager<SignInManager<ApplicationUser>>();

            // TODO JWT services Authentication setup.
            return services;
        }
    }
}