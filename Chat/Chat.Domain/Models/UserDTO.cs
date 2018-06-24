using System.ComponentModel.DataAnnotations;

namespace Chat.Domain.Models
{
    public class UserDTO : IUserDTO
    {
        public UserDTO(string name, string password)
        {
            Name = name;
            Password = password;
        }
        
        public int Id { get; }

        public string Name { get; }

        public string Password { get; }
    }
}
