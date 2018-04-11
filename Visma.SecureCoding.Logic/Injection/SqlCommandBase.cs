using Visma.SecureCoding.Logic.Contracts.Injection;

namespace Visma.SecureCoding.Logic.Injection
{
    public abstract class SqlCommandBase : SqlStatementBase, ISqlCommand
    {
        #region Constructors

        protected SqlCommandBase(string connectionString)
            : base(connectionString)
        {
        }

        #endregion
    }
}