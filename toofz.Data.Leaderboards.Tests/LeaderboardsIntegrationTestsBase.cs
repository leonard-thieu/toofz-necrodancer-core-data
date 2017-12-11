using System;
using Xunit;

namespace toofz.Data.Tests.Leaderboards
{
    [Trait("Category", "Uses SQL Server")]
    [Collection("Uses SQL Server")]
    public abstract class LeaderboardsIntegrationTestsBase : IDisposable
    {
        public LeaderboardsIntegrationTestsBase(bool initialize = true)
        {
            connectionString = StorageHelper.GetDatabaseConnectionString(nameof(LeaderboardsContext));
            db = new LeaderboardsContext(connectionString);

            db.Database.Delete(); // Make sure it really dropped - needed for dirty database
            if (initialize)
            {
                db.Database.Initialize(force: true);
            }
        }

        protected readonly string connectionString;
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
                db?.Database.Delete();
            }

            disposed = true;
        }

        #endregion
    }
}
