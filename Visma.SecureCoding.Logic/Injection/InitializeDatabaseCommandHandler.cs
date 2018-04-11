using System;
using Visma.SecureCoding.DataAccess.Contracts;
using Visma.SecureCoding.Logic.Contracts.Injection;

namespace Visma.SecureCoding.Logic.Injection
{
    public class InitializeDatabaseCommandHandler : IInitializeDatabaseCommandHandler
    {
        #region Private variables

        private readonly ISqlWrapper _sqlWrapper;

        #endregion

        #region Constructors

        public InitializeDatabaseCommandHandler(ISqlWrapper sqlWrapper)
        {
            if (sqlWrapper == null) throw new ArgumentNullException(nameof(sqlWrapper));

            _sqlWrapper = sqlWrapper;
        }

        #endregion

        #region Methods

        public void Execute(IInitializeDatabaseCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            _sqlWrapper.ExecuteNonQuery(command.ConnectionString, command.Statement);
        }

        #endregion
    }
}