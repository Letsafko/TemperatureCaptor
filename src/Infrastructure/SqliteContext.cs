using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public sealed class SqliteContext : DbContext
    {
        public SqliteContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SensorDao>().ToTable("sensor");
        }

        public DbSet<SensorDao> Sensors { get; set; }
    }
}
