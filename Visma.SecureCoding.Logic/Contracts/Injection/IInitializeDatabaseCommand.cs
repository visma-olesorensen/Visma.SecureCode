using Visma.SecureCoding.Infrastructure.Contracts;

namespace Visma.SecureCoding.Logic.Contracts.Injection
{
    public interface IInitializeDatabaseCommand : ISqlCommand
    {
        string Statement { get; }
    }
}