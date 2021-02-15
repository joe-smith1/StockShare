using Microsoft.AspNetCore.Http;
using SPA.Interfaces;

namespace SPA.Extensions
{
    /// <summary>
    /// This class contains the extension methods for the HttpResponse class.
    /// These methods will group the adding of specific headers to the response
    /// related to the action method. e.g for pagination we add the properties required
    /// to display info regarding the current page in the headers of the response.
    /// </summary>
    public static class ResponseExtensions
    {
        /// <summary>
        /// This extension method adds the required pagination properties from <paramref name="paginationProps"/>
        /// to the <paramref name="httpResponse"/> headers of the action method returning the <see cref="HttpResponse"/>.
        /// This extension allows this to be added in a clean fluid way.
        /// </summary>
        /// <param name="httpResponse">The <see cref="HttpResponse"/> that the headers are to be added too.</param>
        /// <param name="paginationProps">
        /// The pagination object to be returned along with the response that has the required default pagination properties
        /// by implementing <see cref="IPagedProps"/>. These required properties are added as headers to the response.
        /// </param>
        public static void AddPaginationHeaders(this HttpResponse httpResponse, IPagedProps paginationProps)
        {
            httpResponse.Headers.Add("Current-Page", paginationProps.CurrentPage.ToString());
            httpResponse.Headers.Add("Page-Size", paginationProps.PageSize.ToString());
            httpResponse.Headers.Add("Total-Pages", paginationProps.TotalPages.ToString());
            httpResponse.Headers.Add("Total-Items", paginationProps.TotalItems.ToString());
        }
    }
}