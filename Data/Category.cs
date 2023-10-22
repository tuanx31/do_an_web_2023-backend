using System.ComponentModel.DataAnnotations;

namespace web_api.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string name { get; set; } = "";
        [Required]
        public string path { get; set; } = "";

        public virtual ICollection <Product> products { get; set; }
    }
}
