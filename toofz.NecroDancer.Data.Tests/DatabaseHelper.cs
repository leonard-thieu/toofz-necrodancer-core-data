using System;
using System.Configuration;

namespace toofz.NecroDancer.Data.Tests
{
    internal static class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            return Environment.GetEnvironmentVariable("NecroDancerContextTestConnectionString", EnvironmentVariableTarget.Machine) ??
                ConfigurationManager.ConnectionStrings[nameof(NecroDancerContext)].ConnectionString;
        }
    }
}
