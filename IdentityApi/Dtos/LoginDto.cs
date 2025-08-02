using System.ComponentModel.DataAnnotations;

namespace IdentityApi.Dtos
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
