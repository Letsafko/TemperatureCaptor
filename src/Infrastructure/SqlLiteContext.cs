using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public sealed class SqlLiteContext : DbContext
    {
        public SqlLiteContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TemperatureDao>().ToTable("temperature");
        }

        public DbSet<TemperatureDao> Temperatures { get; set; }
    }
}
