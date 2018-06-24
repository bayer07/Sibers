namespace Chat.Domain.Validators
{
    public class RegisterUserValidator
    {
        public bool IsUserValid(string userName, string password)
        {
            return !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password);
        }
    }
}
