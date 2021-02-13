namespace SPA.Interfaces
{
    /// <summary>
    /// This Interface defines the default properties that are required for a PagedList
    /// as these properties are required for the response or the response header to
    /// inform the client of paging information.
    /// </summary>
    public interface IPagedProps
    {
        /// <summary>
        /// The current page that the collection is for aka
        /// the items stored in the list are for this page.
        /// </summary>
        int CurrentPage { get; set; }

        /// <summary>
        /// Total number of pages calculated from
        /// <see cref="TotalItems"/> and <see cref="PageSize"/>.
        /// </summary>
        int TotalPages { get; set; }

        /// <summary>
        /// How many items are on each page.
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// The total size of the query used to create the pagination request
        /// e.g all the public stocks.
        /// </summary>
        int TotalItems { get; set; }
    }
}