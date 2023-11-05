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
        public string? description { get; set; }

        [Range(0, double.MaxValue)]
        public double price { get; set; }

        public bool hot { get; set; }
        public string img { get; set; } = "";

        public byte sale_of { get; set; }

        public string design { get; set; } = "";

        public string Material { get; set; } = "";

        public string consistent { get; set; } = "";

        public int quantity { get; set; }

        public string color { get; set; } = "";

        public string size { get; set; } = "";

        public string listImage { get; set; } = "";

        public DateTime createAt { get; set; }

        public int? id_category { get; set; }

        [ForeignKey("id_category")]
        public Category categories { get; set; }

        public int? id_trademark { get; set; }

        [ForeignKey("id_trademark")]
        public Trademark trademarks { get; set; }


        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [NotMapped]
        public IFormFileCollection? listImageFile { get; set; }
    }
}
