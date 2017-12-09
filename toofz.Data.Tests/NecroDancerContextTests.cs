using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using toofz.Data.NecroDancer.Migrations;
using toofz.NecroDancer.Data;
using Xunit;
using Xunit.Sdk;

namespace toofz.Data.Tests
{
    public class NecroDancerContextTests
    {
        private readonly NecroDancerContext db = new NecroDancerContext();

        public class Constructor
        {
            [DisplayFact(nameof(NecroDancerContext))]
            public void ReturnsNecroDancerContext()
            {
                // Arrange -> Act
                var db = new NecroDancerContext();

                // Assert
                Assert.IsAssignableFrom<NecroDancerContext>(db);
            }
        }

        public class Constructor_String
        {
            [DisplayFact(nameof(NecroDancerContext))]
            public void ReturnsNecroDancerContext()
            {
                // Arrange
                var connectionString = StorageHelper.GetDatabaseConnectionString(nameof(NecroDancerContext));

                // Act
                var db = new NecroDancerContext(connectionString);

                // Assert
                Assert.IsAssignableFrom<NecroDancerContext>(db);
            }
        }

        public class ItemsProperty : NecroDancerContextTests
        {
            [DisplayFact(nameof(DbSet))]
            public void ReturnsDbSet()
            {
                // Arrange -> Act
                var items = db.Items;

                // Assert
                Assert.IsAssignableFrom<DbSet<Item>>(items);
            }
        }

        public class EnemiesProperty : NecroDancerContextTests
        {
            [DisplayFact(nameof(DbSet))]
            public void ReturnsDbSet()
            {
                // Arrange -> Act
                var enemies = db.Enemies;

                // Assert
                Assert.IsAssignableFrom<DbSet<Enemy>>(enemies);
            }
        }

        public class IntegrationTests : NecroDancerIntegrationTestsBase
        {
            [DisplayFact]
            public void PreGeneratedMappingViewsAreUpToDate()
            {
                db.Items.FirstOrDefault();
                db.Enemies.FirstOrDefault();
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
