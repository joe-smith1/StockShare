using System;
using SPA.Helpers;
using SPA.Interfaces;

namespace SPA.Models.Wrappers
{
    /// <summary>
    /// Response wrapper used for returning paginated items of type <see cref="T"/> that implement
    /// <see cref="IPagedProps"/>.
    /// Provides properties required for pagination e.g CurrentPage PageSize TotalItems
    /// these are set from the underlying data as that implements <see cref="IPagedProps"/>.
    /// </summary>
    /// <typeparam name="T">The type of paginated data to be returned in response.</typeparam>
    public class PagedResponse<T> : Response<T> where T : IPagedProps
    {
        /// <summary>
        /// Creates a wrapper to return the paginated data in the response with pagination
        /// properties.
        /// </summary>
        /// <param name="data">The underlying paginated items to return.</param>
        public PagedResponse(T data)
        {
            CurrentPage = data.CurrentPage;
            Data = data;
            PageSize = data.PageSize;
            TotalPages = data.TotalPages;
            TotalItems = data.TotalItems;
        }

        /// <summary>
        /// The number of the current page being returned.
        /// </summary>
        public int CurrentPage { get; set; }

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