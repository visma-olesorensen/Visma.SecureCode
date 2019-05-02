using System.Collections.Generic;
using Visma.SecureCoding.Domain.Contracts;
using Visma.SecureCoding.Infrastructure.Contracts;

namespace Visma.SecureCoding.Logic.Contracts.Injection
{
    public interface IDisallowedSqlInjectionQueryHandler : IQueryHandler<IFilteredAccountCollectionQuery, IEnumerable<IAccount>>
    {
    }
}