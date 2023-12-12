using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIurlshortener.Entities
{
    public class Urls
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string UrlLarge { get; set; }

        public string UrlShort { get; set; }

        public int counter { get; set; }

        public int ID_category { get; set; }

        public int ID_user { get; set; }
        public Category Category { get; set; }

        public User User { get; set; }
    }
}
