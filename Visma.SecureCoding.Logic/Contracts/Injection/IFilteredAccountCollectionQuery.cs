using Visma.SecureCoding.Infrastructure.Contracts;

namespace Visma.SecureCoding.Logic.Contracts.Injection
{
    public interface IFilteredAccountCollectionQuery : ISqlQuery
    {
        string Filter { get; }
    }
}