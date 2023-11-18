using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Data
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }


        public int amount { get; set; }

        public double price { get; set; }
        public string color { get; set; } = string.Empty;
        public string size { get; set; } = string.Empty;

        [Required]
        public int id_product { get; set; }
        [ForeignKey("id_product")]
        public Product? Product { get; set; }

        [Required]
        public int id_order { get; set; }
        [ForeignKey("id_order")]
        public Order? Order {  get; set; } 
    }
}
