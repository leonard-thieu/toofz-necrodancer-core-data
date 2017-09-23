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

        void Initialize()
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Enemy> Enemies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var configs = modelBuilder.Configurations;
            configs.Add(new ItemConfiguration());
            configs.Add(new EnemyConfiguration());

            modelBuilder.ComplexType<DisplayString>();
            modelBuilder.ComplexType<Bouncer>();
            modelBuilder.ComplexType<Frame>();
            modelBuilder.ComplexType<OptionalStats>();
            modelBuilder.ComplexType<Particle>();
            modelBuilder.ComplexType<Shadow>();
            modelBuilder.ComplexType<SpriteSheet>();
            modelBuilder.ComplexType<Stats>();
            modelBuilder.ComplexType<Tweens>();
        }
    }
}
