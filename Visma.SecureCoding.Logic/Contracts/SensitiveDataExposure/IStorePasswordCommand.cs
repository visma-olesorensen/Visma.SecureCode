using Visma.SecureCoding.Infrastructure.Contracts;

namespace Visma.SecureCoding.Logic.Contracts.SensitiveDataExposure
{
    public interface IStorePasswordCommand : ICommand
    {
        string PasswordToStore { get; }
    }
}