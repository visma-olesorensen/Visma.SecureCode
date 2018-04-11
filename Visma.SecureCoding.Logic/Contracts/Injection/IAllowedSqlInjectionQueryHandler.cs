using System.Collections.Generic;
using Visma.SecureCoding.Domain.Contracts;
using Visma.SecureCoding.Infrastructure.Contracts;

namespace Visma.SecureCoding.Logic.Contracts.Injection
{
    public interface IAllowedSqlInjectionQueryHandler : IQueryHandler<IFilteredAccountCollectionQuery, IEnumerable<IAccount>>
    {
    }
}