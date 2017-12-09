using System;
using System.Collections.Generic;
using Xunit;

namespace toofz.Data.Tests.Leaderboards
{
    public class DailyLeaderboardTests
    {
        public class LeaderboardIdProperty
        {
            [DisplayFact(nameof(DailyLeaderboard.LeaderboardId))]
            public void GetsAndSetsLeaderboardId()
            {
                // Arrange -> Act
                var dailyLeaderboard = new DailyLeaderboard { LeaderboardId = 43895 };

                // Act -> Assert
                Assert.Equal(43895, dailyLeaderboard.LeaderboardId);
            }
        }

        public class EntriesProperty
        {
            [DisplayFact(nameof(DailyLeaderboard.Entries))]
            public void GetsEntries()
            {
                // Arrange
                var dailyLeaderboard = new DailyLeaderboard();

                // Act -> Assert
                Assert.IsAssignableFrom<List<DailyEntry>>(dailyLeaderboard.Entries);
            }
        }

        public class LastUpdateProperty
        {
            [DisplayFact(nameof(DailyLeaderboard.LastUpdate))]
            public void GetsAndSetsLastUpdate()
            {
                // Arrange -> Act
                var dailyLeaderboard = new DailyLeaderboard { LastUpdate = new DateTime(2017, 8, 28, 16, 27, 58) };

                // Act -> Assert
                Assert.Equal(new DateTime(2017, 8, 28, 16, 27, 58), dailyLeaderboard.LastUpdate);
            }
        }

        public class NameProperty
        {
            [DisplayFact(nameof(DailyLeaderboard.Name))]
            public void GetsAndSetsName()
            {
                // Arrange
                var name = "myName";
                var dailyLeaderboard = new DailyLeaderboard();

                // Act
                dailyLeaderboard.Name = name;
                var name2 = dailyLeaderboard.Name;

                // Assert
                Assert.Equal(name, name2);
            }
        }

        public class DisplayNameProperty
        {
            [DisplayFact(nameof(DailyLeaderboard.DisplayName))]
            public void GetsAndSetsDisplayName()
            {
                // Arrange
                var displayName = "MyDisplayName";
                var dailyLeaderboard = new DailyLeaderboard();

                // Act
                dailyLeaderboard.DisplayName = displayName;
                var displayName2 = dailyLeaderboard.DisplayName;

                // Assert
                Assert.Equal(displayName, displayName2);
            }
        }

        public class IsProductionProperty
        {
            [DisplayFact(nameof(DailyLeaderboard.IsProduction))]
            public void GetsAndSetsIsProduction()
            {
                // Arrange -> Act
                var dailyLeaderboard = new DailyLeaderboard { IsProduction = true };

                // Act -> Assert
                Assert.True(dailyLeaderboard.IsProduction);
            }
        }

        public class ProductProperty
        {
            [DisplayFact(nameof(DailyLeaderboard.Product))]
            public void GetsAndSetsProduct()
            {
                // Arrange
                var product = new Product(1, "myProduct", "MyProduct");

                // Act
                var dailyLeaderboard = new DailyLeaderboard { Product = product };
                var product2 = dailyLeaderboard.Product;

                // Assert
                Assert.Same(product, product2);
            }
        }

        public class ProductIdProperty
        {
            [DisplayFact(nameof(DailyLeaderboard.ProductId))]
            public void GetsAndSetsProductId()
            {
                // Arrange -> Act
                var dailyLeaderboard = new DailyLeaderboard { ProductId = 1 };

                // Act -> Assert
                Assert.Equal(1, dailyLeaderboard.ProductId);
            }
        }

        public class DateProperty
        {
            [DisplayFact(nameof(DailyLeaderboard.Date))]
            public void GetsAndSetsDate()
            {
                // Arrange -> Act
                var dailyLeaderboard = new DailyLeaderboard { Date = new DateTime(2017, 8, 28) };

                // Act -> Assert
                Assert.Equal(new DateTime(2017, 8, 28), dailyLeaderboard.Date);
            }
        }
    }
}
