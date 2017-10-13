using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace toofz.NecroDancer.Data.Tests
{
    class NecroDancerContextTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var db = new NecroDancerContext();

                // Assert
                Assert.IsInstanceOfType(db, typeof(NecroDancerContext));
            }
        }

        [TestClass]
        public class Constructor_String
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var connectionString = "Data Source=localhost;Integrated Security=SSPI";

                // Act
                var db = new NecroDancerContext(connectionString);

                // Assert
                Assert.IsInstanceOfType(db, typeof(NecroDancerContext));
            }
        }

        [TestClass]
        public class ItemsProperty
        {
            [TestMethod]
            public void ReturnsDbSet()
            {
                // Arrange
                var db = new NecroDancerContext();

                // Act
                var items = db.Items;

                // Assert
                Assert.IsInstanceOfType(items, typeof(DbSet<Item>));
            }
        }

        [TestClass]
        public class EnemiesProperty
        {
            [TestMethod]
            public void ReturnsDbSet()
            {
                // Arrange
                var db = new NecroDancerContext();

                // Act
                var enemies = db.Enemies;

                // Assert
                Assert.IsInstanceOfType(enemies, typeof(DbSet<Enemy>));
            }
        }

        [TestClass]
        [TestCategory("Uses SQL Server")]
        public class IntegrationTests
        {
            [TestMethod]
            public async Task PreGeneratedMappingViewsIsUpToDate()
            {
                var connectionString = DatabaseHelper.GetConnectionString();
                using (var context = new NecroDancerContext(connectionString))
                {
                    await context.Items.FirstOrDefaultAsync();
                    await context.Enemies.FirstOrDefaultAsync();

                    context.Database.Delete();
                }
            }
        }
    }
}
