namespace web_api.Models
{
    public class OrderDetailModel
    {
        public int amount { get; set; }

        public double price { get; set; }
        public string color { get; set; } = string.Empty;
        public string size { get; set; } = string.Empty;

        public int id_product { get; set; }
        public int id_order { get; set; }


    }
}
