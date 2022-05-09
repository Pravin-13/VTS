using Microsoft.EntityFrameworkCore;
using VTS_API.Extensions;
using VTS_API.Models;

namespace VTS_API.Data
{
    public class VTSDBContext : DbContext
    {
        public VTSDBContext()
        {
        }

        public VTSDBContext(DbContextOptions<VTSDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Default");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.FluentAPIApply();
            base.OnModelCreating(modelBuilder);
        }
    }
}
