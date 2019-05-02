namespace Visma.SecureCoding.Logic.Contracts.Injection
{
    public interface IInitializeDatabaseCommand : ISqlCommand
    {
        string Statement { get; }
    }
}