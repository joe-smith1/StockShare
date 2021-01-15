#nullable enable
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Data.Entities
{
    /// <summary>
    /// This class is used to represent a user of the application storing properties related to there account
    /// as an entity in the database. It is inheriting IdentityUser which provides handling of user name
    /// password etc.
    /// </summary>
    public class ApplicationUser : IdentityUser<int>
    {
        public DateTime SignUpDate { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public uint Points { get; set; }
        public bool PrivateAccount { get; set; }

        // Nullable properties.
        public string? FavoriteStock { get; set; }
        public string? ProfileDescription { get; set; }

        /// <summary>
        /// Preferred Investment Type e.g shorts vs puts bulls vs bears.
        /// </summary>
        public string? InvestmentOrientation { get; set; }
        /// <summary>
        /// Decimal/money value amount of loss/gain.
        /// </summary>
        public decimal? ProfitLoss { get; set; }
        /// <summary>
        /// Amount invested over all stocks not including profit/loss just what was put in.
        /// </summary>
        public decimal? TotalInvested { get; set; }
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// E.g New York, Tokyo, London. The market the user trades on most.
        /// </summary>
        public string? FavoriteMarket { get; set; }

        // Navigational entity relationships.
        // Many to many with ApplicationRoles through ApplicationUserRoles.
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();
    }
}