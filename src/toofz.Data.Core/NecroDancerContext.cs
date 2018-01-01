using Microsoft.EntityFrameworkCore;
using toofz.NecroDancer.Data;

namespace toofz.Data
{
    public class NecroDancerContext : DbContext, INecroDancerContext
    {
        public NecroDancerContext() { }

        public NecroDancerContext(DbContextOptions<NecroDancerContext> options) : base(options) { }

        public DbSet<Item> Items => Set<Item>();
        public DbSet<Enemy> Enemies => Set<Enemy>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StorageHelper.GetLocalDbConnectionString("NecroDancer"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new EnemyConfiguration());
        }
    }
}
