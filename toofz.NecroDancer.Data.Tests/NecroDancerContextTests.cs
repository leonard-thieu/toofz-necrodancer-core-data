using System.Data.Entity;
using System.Linq;
using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests
{
    public class NecroDancerContextTests
    {
        private readonly NecroDancerContext db = new NecroDancerContext();

        public class Constructor
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var db = new NecroDancerContext();

                // Assert
                Assert.IsAssignableFrom<NecroDancerContext>(db);
            }
        }

        public class Constructor_String
        {
            [Fact]
            public void ReturnsInstance()
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
            [Fact]
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
            [Fact]
            public void ReturnsDbSet()
            {
                // Arrange -> Act
                var enemies = db.Enemies;

                // Assert
                Assert.IsAssignableFrom<DbSet<Enemy>>(enemies);
            }
        }

        public class IntegrationTests : IntegrationTestsBase
        {
            [Fact]
            public void PreGeneratedMappingViewsIsUpToDate()
            {
                db.Items.FirstOrDefault();
                db.Enemies.FirstOrDefault();
            }
        }
    }
}
