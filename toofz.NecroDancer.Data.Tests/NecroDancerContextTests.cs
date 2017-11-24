using System.Data.Entity;
using System.Linq;
using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests
{
    public class NecroDancerContextTests
    {
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
                var connectionString = "Data Source=localhost;Integrated Security=SSPI";

                // Act
                var db = new NecroDancerContext(connectionString);

                // Assert
                Assert.IsAssignableFrom<NecroDancerContext>(db);
            }
        }

        public class ItemsProperty
        {
            [Fact]
            public void ReturnsDbSet()
            {
                // Arrange
                var db = new NecroDancerContext();

                // Act
                var items = db.Items;

                // Assert
                Assert.IsAssignableFrom<DbSet<Item>>(items);
            }
        }

        public class EnemiesProperty
        {
            [Fact]
            public void ReturnsDbSet()
            {
                // Arrange
                var db = new NecroDancerContext();

                // Act
                var enemies = db.Enemies;

                // Assert
                Assert.IsAssignableFrom<DbSet<Enemy>>(enemies);
            }
        }

        [Trait("Category", "Uses SQL Server")]
        public class IntegrationTests : DatabaseTestsBase
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
