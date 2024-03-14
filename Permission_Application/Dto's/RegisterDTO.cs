using Permission_Domen.Enums;
using System.ComponentModel.DataAnnotations;

namespace Permission_Application.Dto_s
{
    public class RegisterDTO
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public ERole ERole { get; set; }

    }
}
