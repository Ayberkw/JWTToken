using System.ComponentModel.DataAnnotations;

namespace JWTToken.Models
{
    public class ChangePasswordModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}

