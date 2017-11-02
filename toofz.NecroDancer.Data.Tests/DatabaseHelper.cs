using System;
using System.Configuration;

namespace toofz.NecroDancer.Tests
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
