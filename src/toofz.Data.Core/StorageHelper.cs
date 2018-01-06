using System;
using System.Configuration;
using System.Data.SqlClient;

namespace toofz.Data
{
    /// <summary>
    /// 
    /// </summary>
    public static class StorageHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetDatabaseConnectionString(string name)
        {
            return GetConnectionString(name) ??
                   GetLocalDbConnectionString(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialCatalog"></param>
        /// <returns></returns>
        public static string GetLocalDbConnectionString(string initialCatalog)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(LocalDB)\MSSQLLocalDB";
            builder.InitialCatalog = initialCatalog;
            builder.IntegratedSecurity = true;
            builder.MultipleActiveResultSets = true;

            return builder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetConnectionString(string name)
        {
            return Environment.GetEnvironmentVariable($"{name}ConnectionString", EnvironmentVariableTarget.Machine) ??
                   ConfigurationManager.ConnectionStrings[name]?.ConnectionString;
        }
    }
}
