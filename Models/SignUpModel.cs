using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class SignUpModel
    {
        public string name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

    }
}
