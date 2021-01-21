using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SPA.Models.Entities
{
    /// <summary>
    /// Role entity for use with identity we created it so that there is a many to many
    /// relationship with Application Users aka a user can get to its roles and a role
    /// can get to its users.
    /// </summary>
    public class ApplicationRole : IdentityRole<Guid>
    {
        // Navigational entity relationships.
        // Many to many with ApplicationUsers through ApplicationUserRoles.
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}