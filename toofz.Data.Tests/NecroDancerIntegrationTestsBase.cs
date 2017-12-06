using System;
using Xunit;

namespace toofz.Data.Tests
{
    [Trait("Category", "Uses SQL Server")]
    [Collection("Uses SQL Server")]
    public abstract class NecroDancerIntegrationTestsBase : IDisposable
    {
        public NecroDancerIntegrationTestsBase()
        {
            connectionString = StorageHelper.GetDatabaseConnectionString(nameof(NecroDancerContext));
            db = new NecroDancerContext(connectionString);

            db.Database.Delete(); // Make sure it really dropped - needed for dirty database
            db.Database.Initialize(force: true);
        }

        protected readonly string connectionString;
        protected readonly NecroDancerContext db;

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
