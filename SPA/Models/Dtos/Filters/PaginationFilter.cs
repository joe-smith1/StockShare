using SPA.Models.Wrappers;

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
                else
                {
                    _pageSize = value;
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


        /// <summary>
        /// Property used in the query string to tell the API weather to only
        /// return the pagination properties through the header or to wrap the pagination
        /// in a <see cref="PagedResponse{T}"/> as well as returning the pagination properties like
        /// TotalPages through the headers of the response. This allows the client to decide what
        /// type of response they want to receive.
        /// </summary>
        /// <remarks>
        /// This defaults to false if no value is provided in the query string which results in
        /// the pagination properties only being returned in response headers but the pagination
        /// data is still returned in the body.
        /// </remarks>
        public bool PaginationWrapper { get; set; }
    }
}