using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string name { get; set; } = string.Empty;
    }
}
