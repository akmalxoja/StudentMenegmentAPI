using Permission_Domen.Common;
using Permission_Domen.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Permission_Domen.Entityes
{
    public class User : AuditTable
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
        public ERole ERole { get; set; }
    }
}
