using System;
using System.Collections.Generic;
using System.Data;

namespace Visma.SecureCoding.DataAccess.Contracts
{
    public interface ISqlWrapper
    {
        int ExecuteNonQuery(string connectionString, string sqlStatement);

        IEnumerable<TResult> ExecuteReader<TResult>(string connectionString, string sqlStatement, Func<IDataReader, TResult> resultMapper);

        IEnumerable<TResult> ExecuteReader<TResult>(string connectionString, string sqlStatement, IDictionary<string, object> sqlParameters, Func<IDataReader, TResult> resultMapper);
    }
}