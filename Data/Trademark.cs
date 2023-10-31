using System.ComponentModel.DataAnnotations;

namespace web_api.Data
{
    public class Trademark
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }  = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}
