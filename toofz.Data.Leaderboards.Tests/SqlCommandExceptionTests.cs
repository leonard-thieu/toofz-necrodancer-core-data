using System;
using System.Data.SqlClient;
using Xunit;

namespace toofz.Data.Tests.Leaderboards
{
    public class SqlCommandExceptionTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(SqlCommandException))]
            public void ReturnsSqlCommandException()
            {
                // Arrange
                string message = null;
                SqlException inner = null;
                string commandText = null;

                // Act
                var ex = new SqlCommandException(message, inner, commandText);

                // Assert
                Assert.IsAssignableFrom<SqlCommandException>(ex);
            }

            [DisplayFact(nameof(SqlCommandException.CommandText))]
            public void SetsCommandText()
            {
                // Arrange
                string message = null;
                SqlException inner = null;
                string commandText = "myCommandText";

                // Act
                var ex = new SqlCommandException(message, inner, commandText);

                // Assert
                Assert.Equal(commandText, ex.CommandText);
            }
        }

        public class InnerExceptionProperty
        {
            [DisplayFact(nameof(SqlException))]
            public void ReturnsSqlException()
            {
                // Arrange
                var message = "myMessage";
                var innerException = SqlClientUtil.CreateSqlException();
                var commandText = "myCommandText";
                var ex = new SqlCommandException(message, innerException, commandText);

                // Act
                var innerException2 = ex.InnerException;

                // Assert
                Assert.IsAssignableFrom<SqlException>(innerException2);
            }
        }

        public class ToStringMethod
        {
            [DisplayFact("CommandText", nameof(SqlCommandException), nameof(String))]
            public void CommandTextIsNull_ReturnsSqlCommandExceptionAsString()
            {
                // Arrange
                string message = null;
                SqlException inner = null;
                string commandText = null;

                // Act
                var ex = new SqlCommandException(message, inner, commandText);

                // Assert
                Assert.Equal("toofz.Data.SqlCommandException: Exception of type 'toofz.Data.SqlCommandException' was thrown.", ex.ToString());
            }

            [DisplayFact(nameof(SqlCommandException), nameof(String))]
            public void ReturnsSqlCommandExceptionAsString()
            {
                // Arrange
                string message = null;
                SqlException inner = null;
                string commandText = "myCommandText";

                // Act
                var ex = new SqlCommandException(message, inner, commandText);

                // Assert
                Assert.Equal(@"toofz.Data.SqlCommandException: Exception of type 'toofz.Data.SqlCommandException' was thrown.

myCommandText", ex.ToString(), ignoreLineEndingDifferences: true);
            }
        }
    }
}
