using DbModels.Models;
using Microsoft.EntityFrameworkCore;

namespace Repo.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
    }
}
