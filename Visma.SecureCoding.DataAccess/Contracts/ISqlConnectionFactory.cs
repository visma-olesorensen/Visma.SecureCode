using System.Data;

namespace Visma.SecureCoding.DataAccess.Contracts
{
    public interface ISqlConnectionFactory
    {
        IDbConnection Create(string connectionString);
    }
}