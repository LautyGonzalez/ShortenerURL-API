using APIurlshortener.Utilities;
using Microsoft.AspNetCore.Mvc;
using APIurlshortener.Models;
using APIurlshortener.Entities;
using APIurlshortener.Data;
using Microsoft.AspNetCore.Authorization;

namespace APIurlshortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly URLShortenerContext _context;

        public APIController(URLShortenerContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost]
        public IActionResult PostUrl([FromBody] CreationUrlsDTO LargeUrl)
        {
            string ShortUrl = CreateUrlShort.GenerateShortUrl();

            int userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);

            Urls url = new Urls()
            {
                ID = LargeUrl.Id,
                UrlLarge = LargeUrl.LargeUrl,
                UrlShort = ShortUrl,
                ID_category = LargeUrl.ID_Category,
                ID_user = userId
            };
            _context.Add(url);
            

            var users = _context.User.FirstOrDefault(u => u.ID == userId);

            users.limite--;

            _context.Update(users);
            _context.SaveChanges();

            if(users.limite == 0)
            {
                return BadRequest("Limite alcanzado");
            }
            return Ok(ShortUrl);
        }

        
        [HttpGet("{url}")]
        public IActionResult GetUrldos(string url)
        {
            var aa = _context.Url.FirstOrDefault(s => s.UrlShort == url);

            aa.counter++;

            _context.Update(aa);
            _context.SaveChanges();
            return Redirect(aa.UrlLarge);
        }
    }
}
