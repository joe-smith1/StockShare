using System.Runtime.InteropServices.ComTypes;

namespace SPA.Models.Dtos.Filters
{
    /// <summary>
    /// This PaginationFilter is to be used in for storing and validating the
    /// query string input for the <see cref="PageSize"/> and <see cref="PageSize"/>
    /// for the pagination request.
    /// </summary>
    public class PaginationFilter
    {
        private const int MaxPageSize = 50;

        // Default values set in case the user provides no values in query string.
        private int _pageSize = 10;
        private int _pageNumber = 1;

        /// <summary>
        /// The number of items to include on the page it cannot be less than
        /// 1 or greater than <see cref="MaxPageSize"/>.
        /// </summary>
        public int PageSize
        {
            get => _pageSize;

            set
            {
                if (value < 1)
                {
                    _pageSize = 1;
                }
                else if (value > MaxPageSize)
                {
                    _pageSize = MaxPageSize;
                }
            }
        }

        /// <summary>
        /// The current page number for the pagination request,
        /// it cannot be less than page number 1.
        /// </summary>
        public int PageNumber
        {
            get => _pageNumber;

            set => _pageNumber = (value < 1) ? 1 : value;
        }
    }
}