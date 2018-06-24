namespace Chat.Domain.Models
{
    public interface IUserDTO
    {
        int Id { get; }

        string Name { get; }

        string Password { get; }
    }
}
