using System;
using Xunit;

namespace toofz.NecroDancer.Tests
{
    [Collection("Uses SQL Server")]
    public abstract class DatabaseTestsBase : IDisposable
    {
        public DatabaseTestsBase()
        {
            connectionString = DatabaseHelper.GetConnectionString();
            db = new NecroDancerContext(connectionString);

            db.Database.Delete();  // Make sure it really dropped - needed for dirty database
            db.Database.Initialize(force: true);
        }

        protected readonly string connectionString;
        protected readonly NecroDancerContext db;

        public void Dispose()
        {
            db.Database.Delete();
        }
    }
}
