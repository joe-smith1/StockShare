using Microsoft.AspNetCore.Identity;

namespace API.Data.Entities
{
    /// <summary>
    /// This Entity is used as a relationship table for the many to many relationship between ApplicationUsers
    /// and ApplicationRoles. A User can have many Roles and Roles can have many Users.
    /// It is used as the IdentityUserRole in our database context using identity.
    /// </summary>
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}