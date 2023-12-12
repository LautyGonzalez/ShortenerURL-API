using System.ComponentModel.DataAnnotations;

namespace APIurlshortener.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Urls> url { get; set; }
    }
}
