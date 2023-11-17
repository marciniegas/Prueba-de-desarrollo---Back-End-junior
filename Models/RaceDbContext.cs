using Microsoft.EntityFrameworkCore;

namespace Bovinos.Models
{
    public class RaceDbContext : DbContext
    {
        public RaceDbContext(DbContextOptions<RaceDbContext> options) : base(options)
        {
        }
        public DbSet<Race> Razas { get; set; }
    }
}
