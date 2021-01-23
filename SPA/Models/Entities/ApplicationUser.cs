#nullable enable
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SPA.Models.Entities
{
    /// <summary>
    /// This class is used to represent a user of the application storing properties related to there account
    /// as an entity in the database. It is inheriting IdentityUser which provides handling of user name
    /// password etc.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// When the users account was created.
        /// </summary>
        public DateTime SignUpDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// The last time a user made a request to this api will need to use an action filter.
        /// </summary>
        public DateTime LastActive { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// How many points the user has been given by other users from all time.
        /// Private accounts wont be able to get points.
        /// </summary>
        public uint Points { get; set; }

        /// <summary>
        /// If this users account should be shown to other users and if their stocks should be posted.
        /// </summary>
        public bool PrivateAccount { get; set; }

        /// <summary>
        /// Generic profile description for the user e.g a bio this is optional.
        /// </summary>
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

        /// <summary>
        /// The Date of birth of the user this is not required.
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// E.g New York, Tokyo, London. The market the user trades on most.
        /// </summary>
        public string? FavoriteMarket { get; set; }

        // Navigational entity relationships.

        /// <summary>
        ///  One to many relationship aka many stocks can be owned by one user.
        /// </summary>
        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();

        /// <summary>
        /// Foreign Key to the favorite Stock of the user.
        /// </summary>
        public Stock? FavoriteStock { get; set; }
    }
}