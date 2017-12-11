﻿using System.Data.SqlClient;
using Xunit;

namespace toofz.Data.Tests.Leaderboards
{
    public class SqlCommandAdapterTests
    {
        public class CommandTextProperty
        {
            [DisplayFact(nameof(SqlCommandAdapter.CommandText))]
            public void GetsAndSetsCommandText()
            {
                // Arrange
                var command = new SqlCommand();
                var adapter = new SqlCommandAdapter(command);

                // Act -> Assert
                adapter.CommandText = "myCommandText";
                Assert.Equal("myCommandText", adapter.CommandText);
            }
        }

        public class ParametersProperty
        {
            [DisplayFact(nameof(SqlParameterCollection))]
            public void ReturnsSqlParameterCollection()
            {
                // Arrange
                var command = new SqlCommand();
                var adapter = new SqlCommandAdapter(command);

                // Act
                var parameters = adapter.Parameters;

                // Assert
                Assert.IsAssignableFrom<SqlParameterCollection>(parameters);
            }
        }
    }
}
