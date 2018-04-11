using System;
using System.Data;
using System.Data.SqlClient;
using Visma.SecureCoding.DataAccess.Contracts;

namespace Visma.SecureCoding.DataAccess
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        #region Methods

        public IDbConnection Create(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(nameof(connectionString));

            return new SqlConnection(connectionString);
        }

        #endregion
    }
}