using APIurlshortener.Data;
using APIurlshortener.Entities;
using APIurlshortener.Models;
using APIurlshortener.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIurlshortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userServices;
        private readonly URLShortenerContext _context;

        public UserController (UserServices userServices, URLShortenerContext context) 
        {
            _userServices = userServices;
            _context = context;

        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreationUsersDTO CreationUsersDTO)
        {
            _userServices.CreateUser(CreationUsersDTO);
            return Ok(CreationUsersDTO);
        }

        [HttpGet]
        public IActionResult GetUserUrls()
        {
            int userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);
            var urls = _context.Url.Where(u => u.ID_user == userId).ToList();


            return Ok(urls);
        }

        [HttpGet("attemps")]

        public IActionResult GetAttemps()
        {
            int userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);
            var userLimit = _context.User.FirstOrDefault(u => u.ID == userId);
            return Ok(userLimit.limite);
        }

        [HttpPut]

        public IActionResult ResetLimit()
        {
            int userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);
            var userLimit = _context.User.FirstOrDefault(u => u.ID == userId);

            userLimit.limite = 10;

            _context.Update(userLimit);
            _context.SaveChanges();
            return Ok();
        }
    }
}
