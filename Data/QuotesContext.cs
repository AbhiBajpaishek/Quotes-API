using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quotes_API.Entity;

namespace Quotes_API.Data
{
    public class QuotesContext : IdentityDbContext
    {
        public QuotesContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Quote>().HasData(new Quote
            {
                Id = 1,
                Author = "Abhi",
                Description = "That's a new morning quote.......",
                Title = "New Quote"
            });
        }

        public DbSet<Quote> Quotes { get; set; }
    }
}