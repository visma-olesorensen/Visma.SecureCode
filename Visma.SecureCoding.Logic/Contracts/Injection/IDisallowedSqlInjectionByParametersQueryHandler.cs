using System.Collections.Generic;
using Visma.SecureCoding.Domain.Contracts;
using Visma.SecureCoding.Infrastructure.Contracts;

namespace Visma.SecureCoding.Logic.Contracts.Injection
{
    public interface IDisallowedSqlInjectionByParametersQueryHandler : IQueryHandler<IFilteredAccountCollectionQuery, IEnumerable<IAccount>>
    {
    }
}