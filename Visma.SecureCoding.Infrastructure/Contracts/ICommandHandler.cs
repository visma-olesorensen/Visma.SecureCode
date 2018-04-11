namespace Visma.SecureCoding.Infrastructure.Contracts
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }

    public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand
    {
        TResult Execute(TCommand command);
    }
}