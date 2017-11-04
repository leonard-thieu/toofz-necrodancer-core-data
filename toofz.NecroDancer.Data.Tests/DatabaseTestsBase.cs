using System;

namespace toofz.NecroDancer.Tests
{
    public abstract class DatabaseTestsBase : IDisposable
    {
        public DatabaseTestsBase(DatabaseFixture fixture)
        {
            Db = fixture.Db;

            Db.Database.Delete();  // Make sure it really dropped - needed for dirty database
            Db.Database.Initialize(force: true);
        }

        public NecroDancerContext Db { get; }

        public void Dispose()
        {
            Db.Database.Delete();
        }
    }
}
