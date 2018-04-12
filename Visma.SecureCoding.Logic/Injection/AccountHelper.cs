using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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

        public static string ToText(this IEnumerable<IAccount> accountCollection)
        {
            if (accountCollection == null) throw new ArgumentNullException(nameof(accountCollection));

            StringBuilder textBuilder = new StringBuilder();
            foreach (IAccount account in accountCollection)
            {
                textBuilder.AppendLine(account.ToString());
            }
            return textBuilder.ToString();
        }

       #endregion
    }
}