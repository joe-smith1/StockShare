namespace SPA.Models.Wrappers
{
    /// <summary>
    /// Basic base class wrapper allowing us to return different
    /// properties along with our endpoints responses e.g error messages.
    /// </summary>
    /// <typeparam name="T">The data type intended to be returned.</typeparam>
    public class Response<T>
    {
        /// <summary>
        /// Constructor for an empty response successful by default.
        /// </summary>
        public Response()
        {
            Succeeded = true;
        }

        /// <summary>
        /// Creates a response wrapper for the given data.
        /// </summary>
        /// <param name="data">The original data intended to be returned.</param>
        public Response(T data) : this()
        {
            Data = data;
        }

        /// <summary>
        /// The underlying data to be returned in the response, this is the object that
        /// was intended to be returned.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// If the request to our endpoint was a success.
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// All the messages of errors encountered through the request that are to be returned to the client.
        /// </summary>
        public string[] Errors { get; set; }

        /// <summary>
        /// Additional message along with the response.
        /// </summary>
        public string Message { get; set; }
    }
}