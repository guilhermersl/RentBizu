using Microsoft.EntityFrameworkCore;

namespace RentBizu.Data.Contexto
{
    public class RentBizuContext : DbContext
    {
        public RentBizuContext(DbContextOptions<RentBizuContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RentBizuContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}