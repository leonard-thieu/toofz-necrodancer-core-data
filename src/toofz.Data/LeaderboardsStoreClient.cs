using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace toofz.Data
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class LeaderboardsStoreClient : ILeaderboardsStoreClient
    {
        /// <summary>
        /// Indicates if an exception is a transient fault for <see cref="LeaderboardsStoreClient"/>.
        /// </summary>
        /// <param name="ex">The exception to check.</param>
        /// <returns>
        /// true, if the exception is a transient fault for <see cref="LeaderboardsStoreClient"/>; otherwise, false.
        /// </returns>
        public static bool IsTransient(Exception ex)
        {
            if (ex is SqlCommandException sce)
            {
                // Connection timeout
                // https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlerror.number(v=vs.110).aspx#Remarks
                return sce.InnerException
                    .Errors
                    .OfType<SqlError>()
                    .Any(err => err.Number == -2);
            }

            return false;
        }

        /// <summary>
        /// Initializes an instance of the <see cref="LeaderboardsStoreClient"/> class.
        /// </summary>
        /// <param name="connectionString">The connection used to open the SQL Server database.</param>
        public LeaderboardsStoreClient(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        private readonly SqlConnection connection;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="items"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> BulkInsertAsync<TEntity>(
            IEnumerable<TEntity> items,
            CancellationToken cancellationToken)
            where TEntity : class
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            items = items.ToList();

            await connection.OpenIfClosedAsync(cancellationToken).ConfigureAwait(false);

            var entityType = GetEntityType<TEntity>();

            var schemaName = entityType.SqlServer().Schema ??
                entityType.Model.SqlServer().DefaultSchema ??
                "dbo";
            var tableName = entityType.SqlServer().TableName;
            var viewName = tableName;

            var activeTableName = await connection.GetReferencedTableNameAsync(schemaName, viewName, cancellationToken).ConfigureAwait(false);
            var stagingTableName = activeTableName.EndsWith("_A") ?
                $"{tableName}_B" :
                $"{tableName}_A";

            var columnMappings = entityType.GetProperties().ToDictionary(p => p.Name, p => p.SqlServer().ColumnName);

            await connection.DisableNonclusteredIndexesAsync(stagingTableName, cancellationToken).ConfigureAwait(false);
            // Cannot assume that the staging table is empty even though it's truncated afterwards.
            // This can happen when initially working with a database that was modified by legacy code. Legacy code 
            // truncated at the beginning instead of after.
            await connection.TruncateTableAsync(stagingTableName, cancellationToken).ConfigureAwait(false);
            await BulkCopyAsync(items, stagingTableName, columnMappings, true, cancellationToken).ConfigureAwait(false);
            await connection.RebuildNonclusteredIndexesAsync(stagingTableName, cancellationToken).ConfigureAwait(false);
            await connection.SwitchTableAsync(
                viewName,
                stagingTableName,
                entityType.GetProperties().Select(p => p.Name),
                cancellationToken)
                .ConfigureAwait(false);
            // Active table is now the new staging table
            await connection.TruncateTableAsync(activeTableName, cancellationToken).ConfigureAwait(false);

            return items.Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="items"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> BulkUpsertAsync<TEntity>(
            IEnumerable<TEntity> items,
            BulkUpsertOptions options,
            CancellationToken cancellationToken)
            where TEntity : class
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            items = items.ToList();
            options = options ?? new BulkUpsertOptions();

            if (!items.Any()) { return 0; }

            await connection.OpenIfClosedAsync(cancellationToken).ConfigureAwait(false);

            var entityType = GetEntityType<TEntity>();

            var tableName = entityType.SqlServer().TableName;
            var tempTableName = $"#{tableName}";

            var entityProperties = entityType.GetProperties();
            var columnMappings = entityProperties.ToDictionary(p => p.Name, p => p.SqlServer().ColumnName);

            await connection.SelectIntoTemporaryTableAsync(tableName, tempTableName, cancellationToken).ConfigureAwait(false);
            await BulkCopyAsync(items, tempTableName, columnMappings, false, cancellationToken).ConfigureAwait(false);

            return await connection.MergeAsync(
                tableName,
                tempTableName,
                entityProperties.Select(p => p.SqlServer().ColumnName),
                entityType.FindPrimaryKey().Properties.Select(p => p.SqlServer().ColumnName),
                options.UpdateWhenMatched,
                cancellationToken)
                .ConfigureAwait(false);
        }

        private IEntityType GetEntityType<TEntity>()
            where TEntity : class
        {
            var options = new DbContextOptionsBuilder<NecroDancerContext>()
                .UseSqlServer(connection)
                .Options;

            using (var db = new NecroDancerContext(options))
            {
                return db.Model.GetEntityTypes().FirstOrDefault(t => t.ClrType == typeof(TEntity));
            }
        }

        private async Task BulkCopyAsync<TEntity>(
            IEnumerable<TEntity> items,
            string destinationTableName,
            IDictionary<string, string> columnMappings,
            bool useTableLock,
            CancellationToken cancellationToken)
            where TEntity : class
        {
            var options = SqlBulkCopyOptions.KeepNulls;
            if (useTableLock) { options &= SqlBulkCopyOptions.TableLock; }

            using (var sqlBulkCopy = new SqlBulkCopy(connection, options, externalTransaction: null))
            {
                sqlBulkCopy.BulkCopyTimeout = 0;
                sqlBulkCopy.DestinationTableName = destinationTableName;

                foreach (var columnMapping in columnMappings)
                {
                    sqlBulkCopy.ColumnMappings.Add(columnMapping.Key, columnMapping.Value);
                }

                using (var reader = new TypedDataReader<TEntity>(columnMappings, items))
                {
                    await sqlBulkCopy.WriteToServerAsync(reader, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        #region IDisposable Members

        private bool disposed;

        /// <summary>
        /// Disposes of resources used by <see cref="LeaderboardsStoreClient"/>.
        /// </summary>
        public void Dispose()
        {
            if (disposed) { return; }

            connection.Dispose();

            disposed = true;
        }

        #endregion
    }
}