using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Visma.SecureCoding.DataAccess.Contracts;

namespace Visma.SecureCoding.DataAccess
{
    public class SqlWrapper : ISqlWrapper
    {
        #region Private variables

        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        #endregion

        #region Constructor

        public SqlWrapper(ISqlConnectionFactory sqlConnectionFactory)
        {
            if (sqlConnectionFactory == null) throw new ArgumentNullException(nameof(sqlConnectionFactory));

            _sqlConnectionFactory = sqlConnectionFactory;
        }

        #endregion

        #region Methods

        public int ExecuteNonQuery(string connectionString, string sqlStatement)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(nameof(connectionString));
            if (string.IsNullOrWhiteSpace(sqlStatement)) throw new ArgumentNullException(nameof(sqlStatement));

            using (IDbConnection dbConnection = _sqlConnectionFactory.Create(connectionString))
            {
                dbConnection.Open();
                try
                {
                    using (IDbCommand dbCommand = dbConnection.CreateCommand())
                    {
                        dbCommand.CommandText = sqlStatement;
                        dbCommand.CommandType = CommandType.Text;
                        return dbCommand.ExecuteNonQuery();
                    }
                }
                finally
                {
                    dbConnection.Close();
                }
            }
        }

        public IEnumerable<TResult> ExecuteReader<TResult>(string connectionString, string sqlStatement, Func<IDataReader, TResult> resultMapper)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(nameof(connectionString));
            if (string.IsNullOrWhiteSpace(sqlStatement)) throw new ArgumentNullException(nameof(sqlStatement));
            if (resultMapper == null) throw new ArgumentNullException(nameof(resultMapper));

            using (IDbConnection dbConnection = _sqlConnectionFactory.Create(connectionString))
            {
                dbConnection.Open();
                try
                {
                    using (IDbCommand dbCommand = dbConnection.CreateCommand())
                    {
                        dbCommand.CommandText = sqlStatement;
                        dbCommand.CommandType = CommandType.Text;
                        using (IDataReader dataReader = dbCommand.ExecuteReader())
                        {
                            IList<TResult> result = new List<TResult>();
                            while (dataReader.Read())
                            {
                                result.Add(resultMapper(dataReader));
                            }
                            return result;
                        }
                    }
                }
                finally
                {
                    dbConnection.Close();
                }
            }
        }

        public IEnumerable<TResult> ExecuteReader<TResult>(string connectionString, string sqlStatement, IDictionary<string, object> sqlParameters, Func<IDataReader, TResult> resultMapper)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(nameof(connectionString));
            if (string.IsNullOrWhiteSpace(sqlStatement)) throw new ArgumentNullException(nameof(sqlStatement));
            if (sqlParameters == null) throw new ArgumentNullException(nameof(sqlParameters));
            if (resultMapper == null) throw new ArgumentNullException(nameof(resultMapper));

            using (IDbConnection dbConnection = _sqlConnectionFactory.Create(connectionString))
            {
                dbConnection.Open();
                try
                {
                    using (IDbCommand dbCommand = dbConnection.CreateCommand())
                    {
                        dbCommand.CommandText = sqlStatement;
                        dbCommand.CommandType = CommandType.Text;
                        foreach (KeyValuePair<string, object> sqlParameter in sqlParameters)
                        {
                            IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
                            dbDataParameter.ParameterName = sqlParameter.Key;
                            dbDataParameter.Value = sqlParameter.Value;
                            dbCommand.Parameters.Add(dbDataParameter);
                        }
                        using (IDataReader dataReader = dbCommand.ExecuteReader())
                        {
                            IList<TResult> result = new List<TResult>();
                            while (dataReader.Read())
                            {
                                result.Add(resultMapper(dataReader));
                            }
                            return result;
                        }
                    }
                }
                finally
                {
                    dbConnection.Close();
                }
            }
        }

        #endregion
    }
}