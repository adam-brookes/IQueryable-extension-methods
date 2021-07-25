using Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    /// <summary>
    /// Database Context for the Gym
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }

        public DbSet<Facility> Facilities { get; set; }

        public DbSet<Member> Members { get; set; }
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurations();
        }
    }
}