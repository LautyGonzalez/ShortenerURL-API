using System.ComponentModel.DataAnnotations;

namespace APIurlshortener.Entities
{
    public class Urls
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string? UrlLarge { get; set; }

        public string? UrlShort { get; set; }
    }
}
