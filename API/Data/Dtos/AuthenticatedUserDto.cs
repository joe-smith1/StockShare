namespace API.Data.Dtos
{
    /// <summary>
    /// Basic Authenticated user DTO used to only send back the minimal amount of information
    /// regarding the logged in user. We use the DTO so we don't send back all the information
    /// regarding a user just to show they're now logged in. Only the properties that are always displayed
    /// or required after logging in e.g points.
    /// </summary>
    public class AuthenticatedUserDto
    {
        /// <summary>
        /// Jwt token of the user that just logged in so it
        /// can be stored in the browsers local storage,
        /// this token will be required to make authenticated
        /// user actions.
        /// </summary>
        public string Token { get; set; }

        public string UserName { get; set; }
        public uint Points { get; set; }
        public bool PrivateAccount { get; set; }
    }
}