using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Xml.Linq;

namespace forum_new.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public int RoleId { get; set; }
    }

    public class UserDto
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public int RoleId { get; set; }
    }
}
