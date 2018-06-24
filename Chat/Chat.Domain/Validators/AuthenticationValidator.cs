namespace Chat.Domain.Validators
{
    public class AuthenticationValidator
    {
        public bool IsUserValid(string userName, string password)
        {
            return !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password);
        }
    }
}
