namespace SPA.Models.Dtos
{
    /// <summary>
    /// Basic Authenticated user DTO used to only send back the minimal amount of information
    /// regarding the logged in user. We use the DTO so we don't send back all the information
    /// regarding a user just to show they're now logged in. Only the properties that are always displayed
    /// or required after logging in e.g points.
    /// </summary>
    public class AuthenticatedUserDto
    {
        public string UserName { get; set; }
        public uint Points { get; set; }
        public bool PrivateAccount { get; set; }
    }
}