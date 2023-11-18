namespace web_api.Models
{
    public class OrderModel
    {
        public string note { get; set; }

        public string? nameCustomer { get; set; }

        public string? emailCustomer { get; set; }

        public string? phoneCustomer { get; set; }

        public string? address { get; set; }

        public double total { get; set; }

    }
}
