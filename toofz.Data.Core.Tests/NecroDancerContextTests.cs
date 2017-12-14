using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Design;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using toofz.NecroDancer.Data;
using Xunit;
using Xunit.Sdk;

namespace toofz.Data.Tests
{
    public class NecroDancerContextTests
    {
        public NecroDancerContextTests()
        {
            var options = new DbContextOptionsBuilder<NecroDancerContext>()
                .UseInMemoryDatabase(StorageHelper.GetStorageBaseName(nameof(NecroDancerContext)))
                .Options;
            db = new NecroDancerContext(options);
        }

        private readonly NecroDancerContext db;

        public class Constructor
        {
            [DisplayFact(nameof(NecroDancerContext))]
            public void ReturnsNecroDancerContext()
            {
                // Arrange
                var options = new DbContextOptionsBuilder<NecroDancerContext>()
                    .UseInMemoryDatabase(StorageHelper.GetStorageBaseName(nameof(NecroDancerContext)))
                    .Options;

                // Act
                var db = new NecroDancerContext(options);

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

            // Ported to EF Core from https://stackoverflow.com/a/42643788/414137
            [DisplayFact]
            public void CanMigrateUpAndDown()
            {
                var migrator = db.Database.GetService<IMigrator>();

                // Retrieve migrations
                var migrations = new List<string> { "0" };  // Not sure if "0" is more zero than the first item in list of local migrations
                migrations.AddRange(db.Database.GetMigrations());

                try
                {
                    migrator.Migrate(migrations.First());

                    for (int index = 0; index < migrations.Count; index++)
                    {
                        migrator.Migrate(migrations[index]);
                        if (index > 0)
                            migrator.Migrate(migrations[index - 1]);
                    }

                    migrator.Migrate(migrations.Last());
                }
                catch (SqlException ex)
                {
                    throw new XunitException("Should not have any errors when running migrations up and down: " + ex.Errors[0].Message.ToString());
                }
            }

            [DisplayFact]
            public void ModelChangesAreNotPending()
            {
                var servicesBuilder = new DesignTimeServicesBuilder(Assembly.GetEntryAssembly(), Mock.Of<IOperationReporter>());
                var services = servicesBuilder.Build(db);
                var dependencies = services.GetService<MigrationsScaffolderDependencies>();

                var modelSnapshot = dependencies.MigrationsAssembly.ModelSnapshot;
                Assert.NotNull(modelSnapshot);
                var lastModel = dependencies.SnapshotModelProcessor.Process(modelSnapshot.Model);
                var upOperations = dependencies.MigrationsModelDiffer.GetDifferences(lastModel, dependencies.Model);

                if (upOperations.Any())
                {
                    throw new XunitException("There are pending model changes.");
                }
            }
        }
    }
}
