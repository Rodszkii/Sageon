using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sageon.Models
{
    public class ApplicationDbContext : DbContext
    {
        public IConfiguration Configuration { get; }
        
        public DbSet<Sop> alerts_Sop { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Sageon;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
