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
        public string? ProfileDescription { get; set; }

        /// <summary>
        /// Preferred Investment Type e.g shorts vs puts bulls vs bears.
        /// </summary>
        public string? InvestmentOrientation { get; set; }
        /// <summary>
        /// Decimal/money value amount of loss/gain.
        /// </summary>
        public decimal ProfitLoss { get; set; }
        /// <summary>
        /// Amount invested over all stocks not including profit/loss just what was put in.
        /// </summary>
        public decimal TotalInvested { get; set; }
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// E.g New York, Tokyo, London. The market the user trades on most.
        /// </summary>
        public string? FavoriteMarket { get; set; }

        // Navigational entity relationships.

        /// <summary>
        /// Many to many with ApplicationRoles through ApplicationUserRoles.
        /// </summary>
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();

        /// <summary>
        ///  One to many relationship aka many stocks can be owned by one user.
        /// </summary>
        public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

        /// <summary>
        /// Foreign Key to the favorite Stock of the user.
        /// </summary>
        public virtual Stock? FavoriteStock { get; set; }
    }
}