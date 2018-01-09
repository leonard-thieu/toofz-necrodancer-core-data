using Microsoft.EntityFrameworkCore;
using toofz.NecroDancer.Data;

namespace toofz.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class NecroDancerContext : DbContext, INecroDancerContext, ILeaderboardsContext
    {
        /// <summary>
        /// 
        /// </summary>
        public NecroDancerContext() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public NecroDancerContext(DbContextOptions<NecroDancerContext> options) : base(options) { }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Item> Items => Set<Item>();
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Enemy> Enemies => Set<Enemy>();

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Leaderboard> Leaderboards => Set<Leaderboard>();
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Entry> Entries => Set<Entry>();
        /// <summary>
        /// 
        /// </summary>
        public DbSet<DailyLeaderboard> DailyLeaderboards => Set<DailyLeaderboard>();
        /// <summary>
        /// 
        /// </summary>
        public DbSet<DailyEntry> DailyEntries => Set<DailyEntry>();
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Player> Players => Set<Player>();
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Replay> Replays => Set<Replay>();
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Product> Products => Set<Product>();
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Mode> Modes => Set<Mode>();
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Run> Runs => Set<Run>();
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Character> Characters => Set<Character>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StorageHelper.GetLocalDbConnectionString("NecroDancer"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new EnemyConfiguration());

            modelBuilder.ApplyConfiguration(new LeaderboardConfiguration());
            modelBuilder.ApplyConfiguration(new EntryConfiguration());
            modelBuilder.ApplyConfiguration(new DailyLeaderboardConfiguration());
            modelBuilder.ApplyConfiguration(new DailyEntryConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new ReplayConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ModeConfiguration());
            modelBuilder.ApplyConfiguration(new RunConfiguration());
            modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        }
    }
}
