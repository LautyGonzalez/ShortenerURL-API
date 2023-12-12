using APIurlshortener.Data;
using APIurlshortener.Entities;
using APIurlshortener.Models;

namespace APIurlshortener.Services
{
    public class UserServices
    {
        private readonly URLShortenerContext _context;

        public UserServices(URLShortenerContext context)
        {
            _context = context;
        }

        public void CreateUser(CreationUsersDTO CreationUser)
        {
            User user = new User()
            {
                Username = CreationUser.Username,
                Password = CreationUser.Password
            };
            _context.Add(user);
            _context.SaveChanges();
        }
        
    }
}
