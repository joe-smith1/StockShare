using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Data.Entities
{
    public class ApplicationRole : IdentityRole<int>
    {
        // Navigational entity relationships.

        // Many to many with ApplicationUsers through ApplicationUserRoles.
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}