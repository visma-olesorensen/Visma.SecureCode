namespace Visma.SecureCoding.Infrastructure.Contracts
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery
    {
        TResult Execute(TQuery query);
    }
}