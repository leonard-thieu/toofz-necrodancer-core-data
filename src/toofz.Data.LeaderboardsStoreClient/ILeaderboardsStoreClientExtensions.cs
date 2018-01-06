using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace toofz.Data
{
    /// <summary>
    /// Contains extension methods for <see cref="ILeaderboardsStoreClient"/>.
    /// </summary>
    public static class ILeaderboardsStoreClientExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="storeClient"></param>
        /// <param name="items"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<int> BulkUpsertAsync<TEntity>(
            this ILeaderboardsStoreClient storeClient,
            IEnumerable<TEntity> items,
            CancellationToken cancellationToken)
            where TEntity : class
        {
            if (storeClient == null)
                throw new ArgumentNullException(nameof(storeClient));

            return storeClient.BulkUpsertAsync(items, null, cancellationToken);
        }
    }
}
