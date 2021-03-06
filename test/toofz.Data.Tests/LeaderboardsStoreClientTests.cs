﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace toofz.Data.Tests
{
    public class LeaderboardsStoreClientTests : IDisposable
    {
        public LeaderboardsStoreClientTests()
        {
            var connectionString = StorageHelper.GetDatabaseConnectionString(Constants.LeaderboardsStoreClientName);
            storeClient = new LeaderboardsStoreClient(connectionString);
        }

        private readonly LeaderboardsStoreClient storeClient;

        public void Dispose()
        {
            storeClient.Dispose();
        }

        public class IsTransientMethod
        {
            [DisplayFact(nameof(SqlCommandException), nameof(SqlError), nameof(SqlError.Number))]
            public void ExIsSqlCommandExceptionAndContainsSqlErrorWithNumberIs2_ReturnsTrue()
            {
                // Arrange
                var sqlError = SqlClientUtil.CreateSqlError(-2);
                var sqlException = SqlClientUtil.CreateSqlException(sqlError);
                var ex = new SqlCommandException(null, sqlException, null);

                // Act
                var isTransient = LeaderboardsStoreClient.IsTransient(ex);

                // Assert
                Assert.True(isTransient);
            }

            [DisplayFact(nameof(SqlCommandException), nameof(SqlError), nameof(SqlError.Number))]
            public void ExIsSqlCommandExceptionAndDoesNotContainSqlErrorWithNumberIs2_ReturnsFalse()
            {
                // Arrange
                var sqlError = SqlClientUtil.CreateSqlError(0);
                var sqlException = SqlClientUtil.CreateSqlException(sqlError);
                var ex = new SqlCommandException(null, sqlException, null);

                // Act
                var isTransient = LeaderboardsStoreClient.IsTransient(ex);

                // Assert
                Assert.False(isTransient);
            }

            [DisplayFact(nameof(SqlCommandException))]
            public void ExIsNotSqlCommandException_ReturnsFalse()
            {
                // Arrange
                var ex = new Exception();

                // Act
                var isTransient = LeaderboardsStoreClient.IsTransient(ex);

                // Assert
                Assert.False(isTransient);
            }
        }

        public class Constructor
        {
            [DisplayFact(nameof(LeaderboardsStoreClient))]
            public void ReturnsLeaderboardsStoreClient()
            {
                // Arrange
                var connectionString = StorageHelper.GetDatabaseConnectionString(nameof(NecroDancerContext));

                // Act
                var storeClient = new LeaderboardsStoreClient(connectionString);

                // Assert
                Assert.IsAssignableFrom<LeaderboardsStoreClient>(storeClient);
            }
        }

        public class InsertAsyncMethod : LeaderboardsStoreClientTests
        {
            [DisplayFact(nameof(ArgumentNullException))]
            public async Task ItemsIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                IEnumerable<Entry> items = null;

                // Act -> Assert
                await Assert.ThrowsAsync<ArgumentNullException>(() =>
                {
                    return storeClient.BulkInsertAsync(items, default);
                });
            }

            public class IntegrationTests : IntegrationTestsBase
            {
                [DisplayFact]
                public async Task BulkInsertsItems()
                {
                    // Arrange
                    var items = new[]
                    {
                        new Entry(),
                    };

                    // Act
                    var rowsAffected = await storeClient.BulkInsertAsync(items, default);

                    // Assert
                    Assert.Equal(items.Count(), rowsAffected);
                }
            }
        }

        public class UpsertAsyncMethod : LeaderboardsStoreClientTests
        {
            [DisplayFact(nameof(ArgumentNullException))]
            public async Task ItemsIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                IEnumerable<Player> items = null;

                // Act -> Assert
                await Assert.ThrowsAsync<ArgumentNullException>(() =>
                {
                    return storeClient.BulkUpsertAsync(items, null, default);
                });
            }

            [DisplayFact]
            public async Task ItemsIsEmpty_ShortCircuits()
            {
                // Arrange
                var items = new List<Replay>();

                // Act
                var rowsAffected = await storeClient.BulkUpsertAsync(items, null, default);

                // Assert
                Assert.Equal(0, rowsAffected);
            }

            public class IntegrationTests : IntegrationTestsBase
            {
                [DisplayFact]
                public async Task UpsertsItems()
                {
                    // Arrange
                    var items = new[]
                    {
                        new Player(),
                    };

                    // Act
                    var rowsAffected = await storeClient.BulkUpsertAsync(items, null, default);

                    // Assert
                    Assert.Equal(items.Count(), rowsAffected);
                }
            }
        }
    }
}
