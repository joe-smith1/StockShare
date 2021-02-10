using System;

namespace SPA.Models.Wrappers
{
    /// <summary>
    /// Response wrapper used for returning paginated items of type <see cref="T"/>.
    /// Provides properties required for pagination e.g PageNumber PageSize TotalItems etc.
    /// </summary>
    /// <typeparam name="T">The type of paginated data to be returned in response.</typeparam>
    public class PagedResponse<T> : Response<T>
    {
        /// <summary>
        /// Creates a wrapper to return the paginated data in the response with pagination
        /// properties.
        /// </summary>
        /// <param name="data">The underlying paginated items to return.</param>
        /// <param name="pageNumber">The current page of items being returned.</param>
        /// <param name="pageSize">The number of paginated items on the page.</param>
        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            Data = data;
            PageSize = pageSize;
        }

        /// <summary>
        /// The number of the current page being returned.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// The number of items on the page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The total number of pages to display <see cref="TotalItems"/>.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// The total number of items that can be displayed from the
        /// pagination request.
        /// </summary>
        public int TotalItems { get; set; }
    }
}