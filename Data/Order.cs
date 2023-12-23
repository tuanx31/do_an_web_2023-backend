

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        public string note { get; set; }
        public string idUser { get; set; }
        [ForeignKey("idUser")]
        public ApplicationUser User { get; set; }

        
        public string? address { get; set; }

        public double total { get; set; }

        public DateTime createAt { get; set; }
    }
}
