using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SPA.Helpers
{
    /// <summary>
    /// A List containing the paged items of type <see cref="T"/> created from the given
    /// <see cref="CurrentPage"/> and <see cref="PageSize"/> uses the underlying List
    /// to store the items of the current page.
    /// Must be created using the factory method <see cref="CreateAsync"/>.
    /// </summary>
    /// <typeparam name="T">The type of the item you wish to paginate.</typeparam>
    public class PagedList<T> : List<T>
    {
        /// <summary>
        /// Private constructor as the PagedList should only be created through its factory method <see cref="CreateAsync"/>.
        /// This constructor will set the properties and calculate the total number of pages <see cref="TotalPages"/>
        /// as well as filling the underlying list with the provided <paramref name="items"/>.
        /// </summary>
        /// <param name="items">The items of the page.</param>
        /// <param name="totalItems">The total number of items in the original query to be paginated.</param>
        /// <param name="pageNumber">The current pages number.</param>
        /// <param name="pageSize">The size of the current page.</param>
        private PagedList(IEnumerable<T> items, int totalItems, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            PageSize = pageSize;
            TotalItems = totalItems;

            // Add the items to the underlying base list.
            AddRange(items);
        }

        /// <summary>
        /// The current page that the collection is for aka
        /// the items stored in the list are for this page.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Total number of pages calculated from
        /// <see cref="TotalItems"/> and <see cref="PageSize"/>.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// How many items are on each page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The total size of the query used to create the pagination request
        /// e.g all the public stocks.
        /// </summary>
        public int TotalItems { get; set; }


        /// <summary>
        /// Factory method for creating the PagedList from the provided query <paramref name="sourceQuery"/>
        /// using <paramref name="pageSize"/> and <paramref name="pageNumber"/> uses these properties
        /// to skip the items not included on the page e.g previous page items and only include the items
        /// on the current page in the created PageList.
        /// </summary>
        /// <param name="sourceQuery">
        /// The query to get the items for the list from this is likely to
        /// be a entity framework request e.g to get all public users stocks.
        /// </param>
        /// <param name="pageNumber">The page number for the page to create.</param>
        /// <param name="pageSize">The size of the page to create.</param>
        /// <returns>
        /// A created PagedList with the items for the current page taken from <paramref name="sourceQuery"/>.
        /// </returns>
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> sourceQuery,
            int pageNumber, int pageSize)
        {
            // Number of items returned by the query.
            var totalItems = await sourceQuery.CountAsync();

            // Getting the items on the current page skipping over previous page items.
            var items = await sourceQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .ToListAsync();

            return new PagedList<T>(items, totalItems, pageNumber, pageSize);
        }
    }
}