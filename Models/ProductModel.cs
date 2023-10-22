using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class ProductModel
    {
        [Required]
        public string name { get; set; } = "";
        [Required]
        public string description { get; set; } = "";

        [Range(0, double.MaxValue)]
        public double price { get; set; }

        public string img { get; set; } = "";

        public byte sale_of { get; set; }

        public int? id_category { get; set; }
    }
}
