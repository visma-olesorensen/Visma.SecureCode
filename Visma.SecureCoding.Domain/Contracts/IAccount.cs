namespace Visma.SecureCoding.Domain.Contracts
{
    public interface IAccount
    {
        int Identifier { get; }

        string AccountNumber { get; }

        string AccountName { get; }

        decimal Salary { get; }
    }
}