using System;
using Microsoft.AspNetCore.Identity;

namespace SPA.Models.Entities
{
    /// <summary>
    /// This Entity is used as a join table for the many to many relationship between ApplicationUsers
    /// and ApplicationRoles. A User can have many Roles and Roles can have many Users.
    /// It is used as the IdentityUserRole in our database context using identity.
    /// </summary>
    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}