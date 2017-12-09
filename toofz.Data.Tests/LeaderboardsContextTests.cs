using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using toofz.Data.Leaderboards.Migrations;
using Xunit;
using Xunit.Sdk;

namespace toofz.Data.Tests.Leaderboards
{
    public class LeaderboardsContextTests
    {
        private readonly LeaderboardsContext db = new LeaderboardsContext();

        public class Constructor
        {
            [DisplayFact(nameof(LeaderboardsContext))]
            public void ReturnsLeaderboardsContext()
            {
                // Arrange -> Act
                var db = new LeaderboardsContext();

                // Assert
                Assert.IsAssignableFrom<LeaderboardsContext>(db);
            }
        }

        public class Constructor_String
        {
            [DisplayFact(nameof(LeaderboardsContext))]
            public void ReturnsLeaderboardsContext()
            {
                // Arrange
                var connectionString = StorageHelper.GetDatabaseConnectionString(nameof(LeaderboardsContext));

                // Act
                var db = new LeaderboardsContext(connectionString);

                // Assert
                Assert.IsAssignableFrom<LeaderboardsContext>(db);
            }
        }

        public class LeaderboardsProperty : LeaderboardsContextTests
        {
            [DisplayFact(nameof(DbSet))]
            public void ReturnsDbSet()
            {
                // Arrange -> Act
                var leaderboards = db.Leaderboards;

                // Assert
                Assert.IsAssignableFrom<DbSet<Leaderboard>>(leaderboards);
            }
        }

        public class EntriesProperty : LeaderboardsContextTests
        {
            [DisplayFact(nameof(DbSet))]
            public void ReturnsDbSet()
            {
                // Arrange -> Act
                var entries = db.Entries;

                // Assert
                Assert.IsAssignableFrom<DbSet<Entry>>(entries);
            }
        }

        public class DailyLeaderboardsProperty : LeaderboardsContextTests
        {
            [DisplayFact(nameof(DbSet))]
            public void ReturnsDbSet()
            {
                // Arrange -> Act
                var leaderboards = db.DailyLeaderboards;

                // Assert
                Assert.IsAssignableFrom<DbSet<DailyLeaderboard>>(leaderboards);
            }
        }

        public class DailyEntriesProperty : LeaderboardsContextTests
        {
            [DisplayFact(nameof(DbSet))]
            public void ReturnsDbSet()
            {
                // Arrange -> Act
                var entries = db.DailyEntries;

                // Assert
                Assert.IsAssignableFrom<DbSet<DailyEntry>>(entries);
            }
        }

        public class PlayersProperty : LeaderboardsContextTests
        {
            [DisplayFact(nameof(DbSet))]
            public void ReturnsDbSet()
            {
                // Arrange -> Act
                var players = db.Players;

                // Assert
                Assert.IsAssignableFrom<DbSet<Player>>(players);
            }
        }

        public class ReplaysProperty : LeaderboardsContextTests
        {
            [DisplayFact(nameof(DbSet))]
            public void ReturnsDbSet()
            {
                // Arrange -> Act
                var replays = db.Replays;

                // Assert
                Assert.IsAssignableFrom<DbSet<Replay>>(replays);
            }
        }

        public class ProductsProperty : LeaderboardsContextTests
        {
            [DisplayFact(nameof(DbSet))]
            public void ReturnsDbSet()
            {
                // Arrange -> Act
                var products = db.Products;

                // Assert
                Assert.IsAssignableFrom<DbSet<Product>>(products);
            }
        }

        public class ModesProperty : LeaderboardsContextTests
        {
            [DisplayFact(nameof(DbSet))]
            public void ReturnsDbSet()
            {
                // Arrange -> Act
                var modes = db.Modes;

                // Assert
                Assert.IsAssignableFrom<DbSet<Mode>>(modes);
            }
        }

        public class RunsProperty : LeaderboardsContextTests
        {
            [DisplayFact(nameof(DbSet))]
            public void ReturnsDbSet()
            {
                // Arrange -> Act
                var runs = db.Runs;

                // Assert
                Assert.IsAssignableFrom<DbSet<Run>>(runs);
            }
        }

        public class CharactersProperty : LeaderboardsContextTests
        {
            [DisplayFact(nameof(DbSet))]
            public void ReturnsDbSet()
            {
                // Arrange -> Act
                var characters = db.Characters;

                // Assert
                Assert.IsAssignableFrom<DbSet<Character>>(characters);
            }
        }

        public class IntegrationTests : LeaderboardsIntegrationTestsBase
        {
            [DisplayFact]
            public void PreGeneratedMappingViewsAreUpToDate()
            {
                db.Leaderboards.FirstOrDefault();
                db.Entries.FirstOrDefault();
                db.DailyLeaderboards.FirstOrDefault();
                db.DailyEntries.FirstOrDefault();
                db.Players.FirstOrDefault();
                db.Replays.FirstOrDefault();
                db.Products.FirstOrDefault();
                db.Modes.FirstOrDefault();
                db.Runs.FirstOrDefault();
                db.Characters.FirstOrDefault();
            }

            #region From https://stackoverflow.com/a/42643788/414137

            [DisplayFact]
            public void CanMigrateUpAndDown()
            {
                var configuration = new Configuration();
                var migrator = new DbMigrator(configuration);

                // Retrieve migrations
                var migrations = new List<string> { "0" };  // Not sure if "0" is more zero than the first item in list of local migrations
                migrations.AddRange(migrator.GetLocalMigrations());

                try
                {
                    migrator.Update(migrations.First());

                    for (int index = 0; index < migrations.Count; index++)
                    {
                        migrator.Update(migrations[index]);
                        if (index > 0)
                            migrator.Update(migrations[index - 1]);
                    }

                    migrator.Update(migrations.Last());
                }
                catch (SqlException ex)
                {
                    throw new XunitException("Should not have any errors when running migrations up and down: " + ex.Errors[0].Message.ToString());
                }
            }

            [DisplayFact]
            public void ModelChangesAreNotPending()
            {
                // NOTE: Using MigratorScriptingDecorator so changes won't be made to the database
                var targetDatabase = new DbConnectionInfo(connectionString, "System.Data.SqlClient");
                var migrationsConfiguration = new Configuration { TargetDatabase = targetDatabase };
                var migrator = new DbMigrator(migrationsConfiguration);
                var scriptingMigrator = new MigratorScriptingDecorator(migrator);

                try
                {
                    // NOTE: Using InitialDatabase so history won't be read from the database
                    scriptingMigrator.ScriptUpdate(DbMigrator.InitialDatabase, null);
                }
                catch (AutomaticMigrationsDisabledException)
                {
                    throw new XunitException("Should be no pending model changes/migrations should cover all model changes.");
                }
            }

            #endregion
        }
    }
}
