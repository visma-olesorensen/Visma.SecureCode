using System.Text;
using Visma.SecureCoding.Logic.Contracts.Injection;

namespace Visma.SecureCoding.Logic.Injection
{
    public class InitializeDatabaseCommand : SqlCommandBase, IInitializeDatabaseCommand
    {
        #region Constructors

        public InitializeDatabaseCommand(string connectionString)
            : base(connectionString)
        {
        }

        #endregion

        #region Properties

        public string Statement 
        { 
            get
            {
                StringBuilder statementBuilder = new StringBuilder();
                statementBuilder.AppendLine("CREATE TABLE Accounts (");
                statementBuilder.AppendLine("\tAccountId INT NOT NULL,");
                statementBuilder.AppendLine("\tAccountNumber NVARCHAR(15) NOT NULL,");
                statementBuilder.AppendLine("\tAccountName NVARCHAR(100) NOT NULL,");
                statementBuilder.AppendLine("\tSalary NUMERIC(10, 2) NOT NULL);");
                statementBuilder.AppendLine("INSERT INTO Accounts (AccountId, AccountNumber, AccountName, Salary) VALUES(1, '12340001', 'Jonh Doe', 15000);");
                statementBuilder.AppendLine("INSERT INTO Accounts (AccountId, AccountNumber, AccountName, Salary) VALUES(2, '12340002', 'Jane Peterson', 25000);");
                statementBuilder.AppendLine("INSERT INTO Accounts (AccountId, AccountNumber, AccountName, Salary) VALUES(3, '12340003', 'Jasper Henderson', 10000);");
                return statementBuilder.ToString();
            } 
        }

        #endregion
    }
}