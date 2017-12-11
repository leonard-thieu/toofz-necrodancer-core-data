using System;

namespace toofz.Data.Tests
{
    internal static class StorageHelper
    {
        private const string ProjectName = "DataNecroDancer";

        public static string GetDatabaseConnectionString(string name)
        {
            var baseName = $"Test{ProjectName}{name}";
            var connectionString = GetConnectionString(baseName);
            if (connectionString != null) { return connectionString; }

            return NecroDancerContext.GetLocalDbConnectionString(baseName);
        }

        private static string GetConnectionString(string baseName)
        {
            return Environment.GetEnvironmentVariable($"{baseName}ConnectionString", EnvironmentVariableTarget.Machine);
        }
    }
}
