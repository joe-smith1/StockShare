using System.Text.Json;
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

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            /*
             Grouping all the properties from IPagedProps into the single header through JSON
             As we pass in only the PagedList for example as an IPagedProps then when it is
             serialized only the properties are written. This grouping prevents cluttering of
             headers as they are all related and can be deserialized into an object on the client.
             */
            httpResponse.Headers.Add("Pagination", JsonSerializer.Serialize(paginationProps, options));
        }
    }
}