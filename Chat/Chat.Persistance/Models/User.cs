using Chat.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Persistance.Models
{
    public class User : IUserDTO
    {
        [Key]
        public int Id { get; set; }

        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public string Password { get; set; }
    }
}
