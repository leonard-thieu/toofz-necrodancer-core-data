using System;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace toofz.Data.Tests
{
    [Trait("Category", "Uses SQL Server")]
    [Collection("Uses SQL Server (" + Constants.LeaderboardsStoreClientName + ")")]
    public abstract class IntegrationTestsBase : IDisposable
    {
        public IntegrationTestsBase()
        {
            var connectionString = StorageHelper.GetDatabaseConnectionString(Constants.LeaderboardsStoreClientName);
            var options = new DbContextOptionsBuilder<NecroDancerContext>()
                .UseSqlServer(connectionString)
                .Options;
            db = new NecroDancerContext(options);

            db.Database.EnsureDeleted();
            db.Database.Migrate();
            db.EnsureSeedData();

            storeClient = new LeaderboardsStoreClient(connectionString);
        }

        private readonly NecroDancerContext db;
        protected readonly LeaderboardsStoreClient storeClient;

        #region IDisposable Implementation

        private bool disposed;

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) { return; }

            if (disposing)
            {
                storeClient.Dispose();
                db.Database.EnsureDeleted();
                db.Dispose();
            }

            disposed = true;
        }

        #endregion
    }
}
