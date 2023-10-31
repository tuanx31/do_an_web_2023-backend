using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web_api.Data;

namespace web_api.Models
{
    public class ProductModel
    {
        [Required]
        public string name { get; set; } = "";
        [Required]
        public string? description { get; set; }

        [Range(0, double.MaxValue)]
        public double price { get; set; }

        public string img { get; set; } = "";

        public byte sale_of { get; set; }

        public string design { get; set; } = "";

        public string Material { get; set; } = "";

        public string consistent { get; set; } = "";

        public int quantity { get; set; }

        public string color { get; set; } = "";

        public string size { get; set; } = "";

        public string listImage { get; set; } = "";

        public int? id_category { get; set; }
        public int? id_trademark { get; set; }
    }
}
