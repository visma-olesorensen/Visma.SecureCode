using Visma.SecureCoding.Logic.Contracts.Injection;

namespace Visma.SecureCoding.Logic.Injection
{
    public abstract class SqlQueryBase : SqlStatementBase, ISqlQuery
    {
        #region Constructors

        protected SqlQueryBase(string connectionString)
            : base(connectionString)
        {
        }

        #endregion
    }
}