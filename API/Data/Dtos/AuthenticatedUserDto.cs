namespace API.Data.Dtos
{
    public class AuthenticatedUserDto
    {
        // TODO Document class.
        public string UserName { get; set; }
        public string Token { get; set; }
        public uint Points { get; set; }
        public bool PrivateAccount { get; set; }
    }
}