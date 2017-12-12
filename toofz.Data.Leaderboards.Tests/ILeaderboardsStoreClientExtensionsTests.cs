using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace toofz.Data.Tests.Leaderboards
{
    public class ILeaderboardsStoreClientExtensionsTests
    {
        public class BulkUpsertAsyncMethod
        {
            [DisplayFact("StoreClient", nameof(ArgumentNullException))]
            public async Task StoreClientIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                ILeaderboardsStoreClient storeClient = null;
                var items = new List<object>();
                var cancellationToken = CancellationToken.None;

                // Act -> Assert
                await Assert.ThrowsAsync<ArgumentNullException>(() =>
                {
                    return storeClient.BulkUpsertAsync(items, cancellationToken);
                });
            }

            [DisplayFact(nameof(LeaderboardsStoreClient.BulkUpsertAsync))]
            public async Task CallsBulkUpsertAsyncWithNullOptions()
            {
                // Arrange
                var storeClient = new MockILeaderboardsStoreClient();
                var items = new List<object>();
                var cancellationToken = CancellationToken.None;

                // Act
                await storeClient.BulkUpsertAsync(items, cancellationToken);

                // Assert
                Assert.Equal(1, storeClient.BulkUpsertAsyncCallCount);
            }
        }

        private class MockILeaderboardsStoreClient : ILeaderboardsStoreClient
        {
            public Task<int> BulkInsertAsync<TEntity>(
                IEnumerable<TEntity> items,
                CancellationToken cancellationToken)
                where TEntity : class
            {
                throw new NotImplementedException();
            }

            public int BulkUpsertAsyncCallCount { get; private set; }

            public Task<int> BulkUpsertAsync<TEntity>(
                IEnumerable<TEntity> items,
                BulkUpsertOptions options,
                CancellationToken cancellationToken)
                where TEntity : class
            {
                BulkUpsertAsyncCallCount++;

                return Task.FromResult(items.Count());
            }

            public void Dispose() { }
        }
    }
}
