﻿using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace toofz.Data
{
    /// <summary>
    /// Wraps an instance of <see cref="SqlCommand"/> to provide more detailed error information.
    /// </summary>
    internal sealed class SqlCommandAdapter : IDisposable
    {
        /// <summary>
        /// Creates and returns an instance of <see cref="SqlCommandAdapter"/> that wraps a <see cref="SqlCommand"/> that is
        /// associated with the <see cref="SqlConnection"/>.
        /// </summary>
        /// <param name="connection">The <see cref="SqlConnection"/> to create the command for.</param>
        /// <returns>An instance of <see cref="SqlCommandAdapter"/> that wraps a <see cref="SqlCommand"/>.</returns>
        public static SqlCommandAdapter FromConnection(SqlConnection connection)
        {
            return new SqlCommandAdapter(connection.CreateCommand());
        }

        internal SqlCommandAdapter(SqlCommand command)
        {
            this.command = command;
        }

        private readonly SqlCommand command;

        /// <summary>
        /// Gets or sets the Transact-SQL statement, table name or stored procedure to execute at the data source.
        /// </summary>
        public string CommandText
        {
            get => command.CommandText;
            set => command.CommandText = value;
        }

        /// <summary>
        /// Gets the <see cref="SqlParameterCollection"/>.
        /// </summary>
        public SqlParameterCollection Parameters => command.Parameters;

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected.
        /// </summary>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="SqlCommandException">
        /// SQL Server returned an error while executing the command text.
        /// </exception>
        /// <exception cref="SqlCommandException">
        /// A timeout occurred during a streaming operation. For more information about streaming, see SqlClient 
        /// Streaming Support.
        /// </exception>
        public async Task<int> ExecuteNonQueryAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (SqlException ex)
            {
                throw new SqlCommandException(ex.Message, ex, CommandText);
            }
        }

        /// <summary>
        /// Executes the query asynchronously and returns the first column of the first row 
        /// in the result set returned by the query. Additional columns or rows are ignored.
        /// 
        /// The cancellation token can be used to request that the operation be abandoned before
        /// the command timeout elapses. Exceptions will be reported via the returned <see cref="Task{TResult}"/>
        /// object.
        /// </summary>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        /// <returns>
        /// A task representing the asynchronous operation.
        /// </returns>
        public async Task<object> ExecuteScalarAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (SqlException ex)
            {
                throw new SqlCommandException(ex.Message, ex, CommandText);
            }
        }

        #region IDisposable Members

        private bool disposed;

        /// <summary>
        /// Releases all resources used by the <see cref="SqlCommandAdapter"/>.
        /// </summary>
        public void Dispose()
        {
            if (disposed) { return; }

            command.Dispose();

            disposed = true;
        }

        #endregion IDisposable Members
    }
}