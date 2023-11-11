using APIurlshortener.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIurlshortener.Data
{
    public class URLShortenerContext : DbContext
    {
        public DbSet<Urls> Urls { get; set; }

        public URLShortenerContext(DbContextOptions<URLShortenerContext> options): base(options) {}
    }
}
