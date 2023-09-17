using Microsoft.EntityFrameworkCore;
using STGeneticsTest.Shared.Entities;

namespace STGeneticsTest.Server
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Sex> Sex { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Breed> Breeds { get; set; }

    }
}
