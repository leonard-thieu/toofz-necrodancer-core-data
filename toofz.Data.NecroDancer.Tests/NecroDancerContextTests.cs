using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using toofz.NecroDancer.Data;
using Xunit;
using Xunit.Sdk;

namespace toofz.Data.Tests
{
    public class NecroDancerContextTests
    {
        public NecroDancerContextTests()
        {
            var connectionString = StorageHelper.GetDatabaseConnectionString(nameof(NecroDancerContext));
            db = new NecroDancerContext(connectionString);
        }

        private readonly NecroDancerContext db;

        public class Constructor
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
            [DisplayFact(nameof(DbSet<Item>))]
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
            [DisplayFact(nameof(DbSet<Enemy>))]
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
            public IntegrationTests() : base(createDatabase: false) { }

            #region From https://stackoverflow.com/a/42643788/414137

            // TODO: Needs to test migrating down.
            [DisplayFact]
            public void CanMigrateUpAndDown()
            {
                try
                {
                    db.Database.Migrate();
                }
                catch (SqlException ex)
                {
                    throw new XunitException("Should not have any errors when running migrations up and down: " + ex.Errors[0].Message.ToString());
                }
            }

            [DisplayFact(Skip = "Needs to be updated for EF Core")]
            public void ModelChangesAreNotPending()
            {
                //// NOTE: Using MigratorScriptingDecorator so changes won't be made to the database
                //var targetDatabase = new DbConnectionInfo(connectionString, "System.Data.SqlClient");
                //var migrationsConfiguration = new Configuration { TargetDatabase = targetDatabase };
                //var migrator = new DbMigrator(migrationsConfiguration);
                //var scriptingMigrator = new MigratorScriptingDecorator(migrator);

                //try
                //{
                //    // NOTE: Using InitialDatabase so history won't be read from the database
                //    scriptingMigrator.ScriptUpdate(DbMigrator.InitialDatabase, null);
                //}
                //catch (AutomaticMigrationsDisabledException)
                //{
                //    throw new XunitException("Should be no pending model changes/migrations should cover all model changes.");
                //}
            }

            #endregion
        }
    }
}
