using System.ComponentModel.DataAnnotations;

namespace APIurlshortener.Controllers
{
    public class LargueURL
    {
        public int ID { get; set; }
        
        [Required]
        public string Url { get; set;}
    }
}
