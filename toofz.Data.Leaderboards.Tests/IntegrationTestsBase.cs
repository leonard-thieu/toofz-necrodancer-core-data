using System;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace toofz.Data.Tests
{
    [Trait("Category", "Uses SQL Server")]
    [Collection("Uses SQL Server")]
    public abstract class IntegrationTestsBase : IDisposable
    {
        public IntegrationTestsBase()
        {
            var connectionString = StorageHelper.GetDatabaseConnectionString(nameof(LeaderboardsContext));
            var options = new DbContextOptionsBuilder<LeaderboardsContext>()
                .UseSqlServer(connectionString)
                .Options;
            db = new LeaderboardsContext(options);

            db.Database.EnsureDeleted();
        }

        protected readonly LeaderboardsContext db;

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
                db.Database.EnsureDeleted();
                db.Dispose();
            }

            disposed = true;
        }

        #endregion
    }
}
