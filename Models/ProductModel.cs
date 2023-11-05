using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web_api.Data;

namespace web_api.Models
{
    public class ProductModel
    {
        public string name { get; set; } = "";
        public string? description { get; set; }

        public double price { get; set; }

        public byte sale_of { get; set; }

        public bool hot { get; set; } = false;

        public string design { get; set; } = "";

        public string Material { get; set; } = "";

        public string consistent { get; set; } = "";

        public int quantity { get; set; }

        public string color { get; set; } = "";

        public string size { get; set; } = "";

        public int? id_category { get; set; }
        public int? id_trademark { get; set; }

        [NotMapped]

        public IFormFile? ImageFile { get; set; }

        [NotMapped]

        public IFormFileCollection? listImageFile { get; set; }
    }
    public class HangHoaModel
    {
        public string name { get; set; } = "";
        public string tenloai { get; set; }
    }
}
