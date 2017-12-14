using System;

namespace toofz.Data.Tests
{
    internal static class StorageHelper
    {
        public const string ProjectName = "DataLeaderboardsStoreClient";

        public static string GetStorageBaseName(string name)
        {
            return $"Test{ProjectName}{name}";
        }

        public static string GetDatabaseConnectionString(string name)
        {
            var baseName = GetStorageBaseName(name);
            var connectionString = GetConnectionString(baseName);
            if (connectionString != null) { return connectionString; }

            return LeaderboardsContext.GetLocalDbConnectionString(baseName);
        }

        private static string GetConnectionString(string baseName)
        {
            return Environment.GetEnvironmentVariable($"{baseName}ConnectionString", EnvironmentVariableTarget.Machine);
        }
    }
}
