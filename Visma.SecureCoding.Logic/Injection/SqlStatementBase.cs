using System;
using Visma.SecureCoding.Logic.Contracts.Injection;

namespace Visma.SecureCoding.Logic.Injection
{
    public abstract class SqlStatementBase : ISqlStatement
    {
        #region Constructors

        protected SqlStatementBase(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(nameof(connectionString));

            ConnectionString = connectionString;
        }

        #endregion
        
        #region Properties

        public string ConnectionString { get; private set; }

        #endregion
    }
}