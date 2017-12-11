﻿using System.Linq;
using Xunit;

namespace toofz.Data.Tests.Leaderboards
{
    public class LeaderboardsContextInitializerTests
    {
        public class IntegrationTests : LeaderboardsIntegrationTestsBase
        {
            public IntegrationTests() : base(initialize: false) { }

            [DisplayFact]
            public void SeedsData()
            {
                // Arrange
                var initializer = new LeaderboardsContextInitializer();

                // Act
                initializer.InitializeDatabase(db);

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
