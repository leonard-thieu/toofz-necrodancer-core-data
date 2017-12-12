using Microsoft.EntityFrameworkCore;
using toofz.NecroDancer.Data;

namespace toofz.Data
{
    public class NecroDancerContext : DbContext, INecroDancerContext
    {
        internal static string GetLocalDbConnectionString(string initialCatalog)
        {
            return $@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog={initialCatalog};Integrated Security=True;MultipleActiveResultSets=True";
        }

        public NecroDancerContext() : this((string)null) { }

        public NecroDancerContext(string connectionString)
        {
            this.connectionString = connectionString ?? GetLocalDbConnectionString(nameof(NecroDancerContext));
        }

        public NecroDancerContext(DbContextOptions<NecroDancerContext> options) : base(options) { }

        private readonly string connectionString;

        public DbSet<Item> Items => Set<Item>();
        public DbSet<Enemy> Enemies => Set<Enemy>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new EnemyConfiguration());
        }
    }
}
