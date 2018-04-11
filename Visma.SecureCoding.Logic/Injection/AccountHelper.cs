using System;
using System.Data;
using Visma.SecureCoding.DataAccess;
using Visma.SecureCoding.Domain;
using Visma.SecureCoding.Domain.Contracts;

namespace Visma.SecureCoding.Logic.Injection
{
    public static class AccountHelper
    {
        #region Methods

        public static IAccount ToAccount(this IDataReader dataReader)
        {
            if (dataReader == null) throw new ArgumentNullException(nameof(dataReader));

            int identifier = dataReader.GetInt32(dataReader.GetOrdinal("AccountId"));
            string accountNumber = dataReader.GetString(dataReader.GetOrdinal("AccountNumber"));
            string accountName = dataReader.GetString(dataReader.GetOrdinal("AccountName"));
            decimal salary = dataReader.GetDecimal(dataReader.GetOrdinal("Salary"));

            return new Account(
                identifier,
                accountNumber,
                accountName,
                salary);
        }

       #endregion
    }
}