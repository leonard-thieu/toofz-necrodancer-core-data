using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace toofz.Data.Tests
{
    public class NecroDancerContextExtensionsTests
    {
        public class IntegrationTests : NecroDancerIntegrationTestsBase
        {
            [DisplayFact]
            public void SeedsData()
            {
                // Arrange
                db.Database.Migrate();

                // Act
                db.EnsureSeedData();

                // Assert
                Assert.Equal(2, db.Products.Count());
                Assert.Equal(6, db.Modes.Count());
                Assert.Equal(5, db.Runs.Count());
                Assert.Equal(17, db.Characters.Count());
                Assert.NotEmpty(db.Leaderboards);
                Assert.NotEmpty(db.DailyLeaderboards);
            }
        }
    }
}
