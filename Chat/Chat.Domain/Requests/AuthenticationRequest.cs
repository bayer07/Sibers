namespace Chat.Domain.Requests
{
    public class AuthenticationRequest
    {
        public string name { get; set; }

        public string password { get; set; }
    }
}
