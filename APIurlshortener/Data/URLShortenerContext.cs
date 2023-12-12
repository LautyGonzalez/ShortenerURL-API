using APIurlshortener.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIurlshortener.Data
{
    public class URLShortenerContext : DbContext
    {
        public DbSet<Urls> Url { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<User> User { get; set; }

        public URLShortenerContext(DbContextOptions<URLShortenerContext> options): base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Urls>().HasOne(c => c.Category).WithMany(u => u.url).HasForeignKey(i => i.ID_category);
            modelBuilder.Entity<Urls>().HasOne(u => u.User).WithMany(u => u.Url).HasForeignKey(i => i.ID_user);


            modelBuilder.Entity<Category>().HasData(
                   new Category() { Id = 1, Name = "Ecommerce"},
                   new Category() { Id = 2, Name = "Landing" },
                   new Category() { Id = 3, Name = "SocialMedia" }
                );
        }
    }
}
