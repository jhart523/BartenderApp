using Microsoft.EntityFrameworkCore;
using BartenderApp.Models;


namespace BartenderApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {           
        }

        public DbSet<Cocktail> Cocktails {  get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
