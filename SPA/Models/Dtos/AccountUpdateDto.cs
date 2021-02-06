using System.ComponentModel.DataAnnotations;

namespace SPA.Models.Dtos
{
    /// <summary>
    /// DTO used for mapping the properties from the body of the POST request in Manage/Index
    /// to the logged in users entity.
    /// </summary>
    public class AccountUpdateDto
    {

        /// <summary>
        /// If this users account should be shown to other users and if their stocks should be posted.
        /// </summary>
        [Display(Name = "Private account")]
        public bool PrivateAccount { get; set; }

        /// <summary>
        /// Generic profile description for the user e.g a bio.
        /// </summary>
        [Display(Name = "Description")]
        public string ProfileDescription { get; set; }

        /// <summary>
        /// Preferred Investment Type e.g shorts vs puts bulls vs bears.
        /// </summary>
        [Display(Name = "Investment orientation")]
        public string InvestmentOrientation { get; set; }

        /// <summary>
        /// E.g New York, Tokyo, London. The market the user trades on most.
        /// </summary>
        [Display(Name = "Favorite market")]
        public string FavoriteMarket { get; set; }

        /// <summary>
        /// The Phone number of the user.
        /// </summary>
        [Display(Name = "Phone number")]
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The username used to display representing the user.
        /// </summary>
        [Display(Name = "Username")]
        public string UserName { get; set; }

        /// <summary>
        /// Name of the favorite Stock of the user.
        /// </summary>
        [Display(Name = "Favorite stock")]
        public string FavoriteStockSymbol { get; set; }
    }
}