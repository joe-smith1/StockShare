using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        // Navigational entity relationships.
        // Many to many with ApplicationRoles through ApplicationUserRoles.
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}