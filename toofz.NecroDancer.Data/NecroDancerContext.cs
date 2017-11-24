using System.Data.Entity;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer
{
    public class NecroDancerContext : DbContext, INecroDancerContext
    {
        public NecroDancerContext()
        {
            Initialize();
        }

        public NecroDancerContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Initialize();
        }

        private void Initialize()
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Item> Items => Set<Item>();
        public DbSet<Enemy> Enemies => Set<Enemy>();

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var configs = modelBuilder.Configurations;
            configs.Add(new ItemConfiguration());
            configs.Add(new EnemyConfiguration());
            configs.Add(new StatsConfiguration());
        }
    }
}
