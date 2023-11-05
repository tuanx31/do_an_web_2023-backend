using System.ComponentModel.DataAnnotations;
using web_api.Data;

namespace web_api.Models
{
    public class CategoryModel
    {
        [Required]
        public string name { get; set; } = "";
        [Required]
        public string path { get; set; } = "";

    }
}
