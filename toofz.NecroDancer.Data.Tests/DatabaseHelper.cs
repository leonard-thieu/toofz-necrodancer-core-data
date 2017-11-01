using System;

namespace toofz.NecroDancer.Data.Tests
{
    internal static class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            return Environment.GetEnvironmentVariable("NecroDancerContextTestConnectionString", EnvironmentVariableTarget.Machine) ??
                "Data Source=localhost;Initial Catalog=NecroDancerTestDb;Integrated Security=SSPI";
        }
    }
}
