using System.ComponentModel.DataAnnotations;

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
