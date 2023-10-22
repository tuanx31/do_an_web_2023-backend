using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Data
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; } = "";
        [Required]
        public string? description { get; set; }

        [Range(0, double.MaxValue)]
        public double price { get; set; }

        public string img { get; set; } = "";

        public byte sale_of { get; set; }


        public int? id_category { get; set; }

        [ForeignKey("id_category")]
        public Category categories { get; set; }
    }
}
