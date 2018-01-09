using System;
using System.Data.SqlClient;
using System.Linq;
using Xunit;

namespace toofz.Data.Tests
{
    public class SqlClientUtilTests
    {
        public class CreateSqlErrorMethod_Int32
        {
            [DisplayFact(nameof(SqlError))]
            public void ReturnsSqlError()
            {
                // Arrange
                int infoNumber = 0;

                // Act
                var error = SqlClientUtil.CreateSqlError(infoNumber);

                // Assert
                Assert.IsAssignableFrom<SqlError>(error);
            }
        }

        public class CreateSqlErrorMethod
        {
            [DisplayFact(nameof(SqlError))]
            public void ReturnsSqlError()
            {
                // Arrange
                int infoNumber = 0;
                byte errorState = 0;
                byte errorClass = 0;
                string server = "server";
                string errorMessage = "errorMessage";
                string procedure = "procedure";
                int lineNumber = 0;
                uint win32ErrorCode = 0;

                // Act
                var error = SqlClientUtil.CreateSqlError(infoNumber, errorState, errorClass, server, errorMessage, procedure, lineNumber, win32ErrorCode);

                // Assert
                Assert.IsAssignableFrom<SqlError>(error);
            }
        }

        public class CreateSqlErrorCollectionMethod
        {
            [DisplayFact(nameof(SqlErrorCollection))]
            public void HasNoParams_ReturnsSqlErrorCollection()
            {
                // Arrange -> Act
                var errorCollection = SqlClientUtil.CreateSqlErrorCollection();

                // Assert
                Assert.IsAssignableFrom<SqlErrorCollection>(errorCollection);
            }

            [DisplayFact(nameof(SqlErrorCollection))]
            public void HasParams_ReturnsSqlErrorCollectionWithErrors()
            {
                // Arrange
                var sqlError = SqlClientUtil.CreateSqlError(0);

                // Act
                var errorCollection = SqlClientUtil.CreateSqlErrorCollection(sqlError);

                // Assert
                Assert.Contains(sqlError, errorCollection.OfType<SqlError>());
            }
        }

        public class AddMethod
        {
            [DisplayFact]
            public void AddsError()
            {
                // Arrange
                var errorCollection = SqlClientUtil.CreateSqlErrorCollection();
                int infoNumber = 0;
                byte errorState = 0;
                byte errorClass = 0;
                string server = "server";
                string errorMessage = "errorMessage";
                string procedure = "procedure";
                int lineNumber = 0;
                uint win32ErrorCode = 0;
                var error = SqlClientUtil.CreateSqlError(infoNumber, errorState, errorClass, server, errorMessage, procedure, lineNumber, win32ErrorCode);

                // Act
                errorCollection.Add(error);

                // Assert
                Assert.Same(error, errorCollection[0]);
            }
        }

        public class CreateSqlExceptionMethod_Params_Array_SqlError
        {
            [DisplayFact(nameof(SqlException))]
            public void HasNoParams_ReturnsSqlException()
            {
                // Arrange -> Act
                var ex = SqlClientUtil.CreateSqlException();

                // Assert
                Assert.IsAssignableFrom<SqlException>(ex);
            }

            [DisplayFact(nameof(SqlException))]
            public void HasParams_ReturnsSqlExceptionWithErrors()
            {
                // Arrange
                var sqlError = SqlClientUtil.CreateSqlError(0);

                // Act
                var ex = SqlClientUtil.CreateSqlException(sqlError);

                // Assert
                Assert.Contains(sqlError, ex.Errors.OfType<SqlError>());
            }
        }

        public class CreateSqlExceptionMethod_String_Exception_Guid_Params_Array_SqlError
        {
            private readonly string message = "myMessage";
            private readonly Exception innerException = new Exception();
            private readonly Guid conId = new Guid();

            [DisplayFact(nameof(SqlException))]
            public void HasNoParams_ReturnsSqlException()
            {
                // Arrange -> Act
                var ex = SqlClientUtil.CreateSqlException(message, innerException, conId);

                // Assert
                Assert.IsAssignableFrom<SqlException>(ex);
            }

            [DisplayFact(nameof(SqlException))]
            public void HasParams_ReturnsSqlExceptionWithErrors()
            {
                // Arrange
                var sqlError = SqlClientUtil.CreateSqlError(0);

                // Act
                var ex = SqlClientUtil.CreateSqlException(message, innerException, conId, sqlError);

                // Assert
                Assert.Contains(sqlError, ex.Errors.OfType<SqlError>());
            }
        }

        public class CreateSqlExceptionMethod
        {
            private readonly string message = "myMessage";
            private readonly SqlErrorCollection errorCollection = SqlClientUtil.CreateSqlErrorCollection();
            private readonly Exception innerException = new Exception();
            private readonly Guid conId = new Guid();

            [DisplayFact(nameof(SqlException))]
            public void ReturnsSqlException()
            {
                // Arrange -> Act
                var sqlException = SqlClientUtil.CreateSqlException(message, errorCollection, innerException, conId);

                // Assert
                Assert.IsAssignableFrom<SqlException>(sqlException);
            }
        }
    }
}
