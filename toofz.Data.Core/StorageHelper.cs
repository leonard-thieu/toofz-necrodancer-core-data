using System;
using System.Configuration;
using System.Data.SqlClient;

namespace toofz.Data
{
    public static class StorageHelper
    {
        public static string GetDatabaseConnectionString(string name)
        {
            var connectionString = GetConnectionString(name);
            if (connectionString != null) { return connectionString; }

            return GetLocalDbConnectionString(name);
        }

        public static string GetLocalDbConnectionString(string initialCatalog)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(LocalDB)\MSSQLLocalDB";
            builder.InitialCatalog = initialCatalog;
            builder.IntegratedSecurity = true;
            builder.MultipleActiveResultSets = true;

            return builder.ToString();
        }

        private static string GetConnectionString(string name)
        {
            return Environment.GetEnvironmentVariable($"{name}ConnectionString", EnvironmentVariableTarget.Machine) ??
                   ConfigurationManager.ConnectionStrings[name]?.ConnectionString;
        }
    }
}
