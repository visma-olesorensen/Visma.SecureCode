using Visma.SecureCoding.Infrastructure.Contracts;

namespace Visma.SecureCoding.Logic.Contracts.Injection
{
    public interface ISqlCommand : ISqlStatement, ICommand
    {
    }
}