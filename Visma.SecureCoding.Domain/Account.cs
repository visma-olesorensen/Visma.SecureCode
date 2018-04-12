using System;
using Visma.SecureCoding.Domain.Contracts;

namespace Visma.SecureCoding.Domain
{
    public class Account : IAccount
    {
        #region Constructor

        public Account(int identifier, string accountNumber, string accountName, decimal salary)
        {
            if (string.IsNullOrWhiteSpace(accountNumber)) throw new ArgumentNullException(nameof(accountNumber));
            if (string.IsNullOrWhiteSpace(accountName)) throw new ArgumentNullException(nameof(accountName));

            Identifier = identifier;
            AccountNumber = accountNumber;
            AccountName = accountName;
            Salary = salary;
        }

        #endregion

        #region Properties

        public int Identifier { get; private set; }

        public string AccountNumber { get; private set; }

        public string AccountName { get; private set; }

        public decimal Salary { get; private set; }
        
        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{AccountNumber} - {AccountName}\tSalary: {Salary.ToString("C")}";
        }

        #endregion
    }
}