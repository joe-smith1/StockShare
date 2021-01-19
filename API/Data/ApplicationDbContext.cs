using API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    /// <summary>
    /// Application context representing the database for our application.
    /// Stores the tables and their properties/relations. Using an IdentityDbContext
    /// so the database can be provided with all the additional features that come with
    /// identity e.g automatically normalized names and secure password salt/hashing.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, IdentityUserClaim<int>,
        ApplicationUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many Roles through UserRoles.
                b.HasMany<ApplicationUserRole>(u => u.UserRoles)
                    .WithOne(ur => ur.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

                // Each User can have many Stocks.
                b.HasMany<Stock>(u => u.Stocks)
                    .WithOne(s => s.User)
                    .IsRequired(false);
            });

            builder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many Users through UserRoles.
                b.HasMany<ApplicationUserRole>(r => r.UserRoles)
                    .WithOne(ur => ur.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });
        }
    }
}