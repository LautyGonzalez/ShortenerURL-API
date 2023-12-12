using APIurlshortener.Data;
using APIurlshortener.Entities;
using APIurlshortener.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIurlshortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly URLShortenerContext _context;
        private readonly IConfiguration _config;
        public AuthenticationController(URLShortenerContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        private User? Validate(string user, string password)
        {
            return _context.User.SingleOrDefault(x => x.Username == user && x.Password == password);
        }
        [HttpPost]
        [Route("Authenticate")]
        public ActionResult<string> Auth(AuthDto authDto)
        {
            // Verificamos credenciales
            var user = Validate(authDto.UserName, authDto.Password);

            if (user is null)
            {
                return Forbid(); //si nos devuelve nulo significa que el usuario no existe o la pass está mal
            }

            // Generamos un token según los claims
            var claims = new List<Claim>
    {
            new Claim("id", user.ID.ToString()),
            new Claim("username", user.Username)
    };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(720),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return Ok(new
            {
                AccessToken = jwt
            });
        }
    }
}
