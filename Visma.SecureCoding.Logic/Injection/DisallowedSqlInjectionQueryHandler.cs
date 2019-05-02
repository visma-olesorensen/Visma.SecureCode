using System;
using System.Collections.Generic;
using Visma.SecureCoding.DataAccess.Contracts;
using Visma.SecureCoding.Domain.Contracts;
using Visma.SecureCoding.Logic.Contracts.Injection;

namespace Visma.SecureCoding.Logic.Injection
{
    public class DisallowedSqlInjectionQueryHandler : IDisallowedSqlInjectionQueryHandler
    {
        #region Private variables

        private readonly ISqlWrapper _sqlWrapper;

        #endregion

        #region Constructor

        public DisallowedSqlInjectionQueryHandler(ISqlWrapper sqlWrapper)
        {
            if (sqlWrapper == null) throw new ArgumentNullException(nameof(sqlWrapper));

            _sqlWrapper = sqlWrapper;
        }

        #endregion

        #region Methods

        public IEnumerable<IAccount> Execute(IFilteredAccountCollectionQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            //string sqlStatement = $"SELECT AccountId,AccountNumber,AccountName,Salary FROM Accounts WHERE AccountId={query.Filter}";
            
            //return _sqlWrapper.ExecuteReader(query.ConnectionString, sqlStatement, dataReader => dataReader.ToAccount());

            throw new NotImplementedException();
        }

        #endregion
    }
}