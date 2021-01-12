using API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
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