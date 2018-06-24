using Chat.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Chat.Persistance.Models
{
    public class User : IUserDTO
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
