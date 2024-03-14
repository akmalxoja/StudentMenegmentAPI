using System.ComponentModel.DataAnnotations;

namespace Permission_Application.Dto_s
{
    public class LoginDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
