using Visma.SecureCoding.Infrastructure.Contracts;

namespace Visma.SecureCoding.Logic.Contracts.Injection
{
    public interface ISqlStatement
    {
        string ConnectionString { get; }
    }
}