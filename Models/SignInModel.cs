using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class AccountModel
    {
        public string email { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string groupname { get; set; }
    }

    public class SignInModel 
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required ]
        public string Password { get; set; }


    }

}
