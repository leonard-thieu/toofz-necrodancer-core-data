using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using Xunit;

namespace toofz.Data.Tests.Leaderboards
{
    public class EntityFrameworkExtensionsTests
    {
        public class GetMappingFragmentMethod : LeaderboardsIntegrationTestsBase
        {
            [Fact]
            public void ReturnsMappingFragment()
            {
                // Arrange -> Act
                var mappingFragment = db.GetMappingFragment<Entry>();

                // Assert
                Assert.IsAssignableFrom<MappingFragment>(mappingFragment);
            }
        }

        public class GetTableNameMethod : LeaderboardsIntegrationTestsBase
        {
            [Fact]
            public void ReturnsTableName()
            {
                // Arrange
                var mappingFragment = db.GetMappingFragment<Entry>();

                // Act
                var tableName = mappingFragment.GetTableName();

                // Assert
                Assert.Equal("Entries", tableName);
            }
        }

        public class GetScalarPropertyMappingsMethod : LeaderboardsIntegrationTestsBase
        {
            [Fact]
            public void ReturnsScalarPropertyMappings()
            {
                // Arrange
                var mappingFragment = db.GetMappingFragment<Entry>();

                // Act
                var mappings = mappingFragment.GetScalarPropertyMappings();

                // Assert
                Assert.IsAssignableFrom<IEnumerable<ScalarPropertyMapping>>(mappings);
            }
        }

        public class GetColumnNamesMethod : LeaderboardsIntegrationTestsBase
        {
            [Fact]
            public void ReturnsColumnNames()
            {
                // Arrange
                var mappingFragment = db.GetMappingFragment<Entry>();

                // Act
                var columnNames = mappingFragment.GetColumnNames();

                // Assert
                var expected = new[]
                {
                    nameof(Entry.LeaderboardId),
                    nameof(Entry.Rank),
                    nameof(Entry.SteamId),
                    nameof(Entry.ReplayId),
                    nameof(Entry.Score),
                    nameof(Entry.Zone),
                    nameof(Entry.Level),
                };
                Assert.Equal(expected, columnNames);
            }
        }

        public class GetPrimaryKeyColumnNamesMethod : LeaderboardsIntegrationTestsBase
        {
            [Fact]
            public void ReturnsPrimaryKeyColumnNames()
            {
                // Arrange
                var mappingFragment = db.GetMappingFragment<Entry>();

                // Act
                var primaryKeyColumnNames = mappingFragment.GetPrimaryKeyColumnNames();

                // Assert
                var expected = new[]
                {
                    nameof(Entry.LeaderboardId),
                    nameof(Entry.Rank),
                };
                Assert.Equal(expected, primaryKeyColumnNames);
            }
        }
    }
}
