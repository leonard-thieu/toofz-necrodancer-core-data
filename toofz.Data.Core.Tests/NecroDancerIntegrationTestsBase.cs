using System;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace toofz.Data.Tests
{
    [Trait("Category", "Uses SQL Server")]
    [Collection("Uses SQL Server")]
    public abstract class NecroDancerIntegrationTestsBase : IDisposable
    {
        public NecroDancerIntegrationTestsBase(bool createDatabase = true)
        {
            var options = new DbContextOptionsBuilder<NecroDancerContext>()
                .UseSqlServer(StorageHelper.GetDatabaseConnectionString(nameof(NecroDancerContext)))
                .Options;
            db = new NecroDancerContext(options);

            db.Database.EnsureDeleted();
            if (createDatabase)
            {
                db.Database.EnsureCreated();
            }
        }

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
                db.Database.EnsureDeleted();
            }

            disposed = true;
        }

        #endregion
    }
}
