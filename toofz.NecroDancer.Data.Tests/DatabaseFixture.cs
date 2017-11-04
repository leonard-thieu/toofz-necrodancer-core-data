using System;

namespace toofz.NecroDancer.Tests
{
    public sealed class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            var connectionString = DatabaseHelper.GetConnectionString();
            Db = new NecroDancerContext(connectionString);
        }

        public NecroDancerContext Db { get; }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}