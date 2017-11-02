using System;
using System.Data.Entity;

namespace toofz.NecroDancer.Tests
{
    public sealed class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<NecroDancerContext>());
            var connectionString = DatabaseHelper.GetConnectionString();
            Db = new NecroDancerContext(connectionString);
            Db.Database.Delete();  // Make sure it really dropped - needed for dirty database
            Db.Database.Initialize(force: true);
        }

        public NecroDancerContext Db { get; }

        public void Dispose()
        {
            Db.Database.Delete();
            Db.Dispose();
        }
    }
}