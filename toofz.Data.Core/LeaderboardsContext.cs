using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace toofz.Data
{
    public class LeaderboardsContext : DbContext, ILeaderboardsContext
    {
        internal static string GetLocalDbConnectionString(string initialCatalog)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                InitialCatalog = initialCatalog,
                IntegratedSecurity = true,
                MultipleActiveResultSets = true,
            };

            return builder.ToString();
        }

        public LeaderboardsContext() { }

        public LeaderboardsContext(DbContextOptions<LeaderboardsContext> options) : base(options) { }

        public DbSet<Leaderboard> Leaderboards => Set<Leaderboard>();
        public DbSet<Entry> Entries => Set<Entry>();
        public DbSet<DailyLeaderboard> DailyLeaderboards => Set<DailyLeaderboard>();
        public DbSet<DailyEntry> DailyEntries => Set<DailyEntry>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Replay> Replays => Set<Replay>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Mode> Modes => Set<Mode>();
        public DbSet<Run> Runs => Set<Run>();
        public DbSet<Character> Characters => Set<Character>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetLocalDbConnectionString("NecroDancer"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
