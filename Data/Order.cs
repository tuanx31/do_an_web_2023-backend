

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace web_api.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        public string note { get; set; }

        public string? nameCustomer { get; set; }

        public string? emailCustomer { get; set; }

        public string? phoneCustomer {  get; set; }
        
        public string? address { get; set; }

        public double total { get; set; }

        public DateTime createAt { get; set; }
    }
}
