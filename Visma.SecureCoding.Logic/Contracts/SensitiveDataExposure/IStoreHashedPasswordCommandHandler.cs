using Visma.SecureCoding.Infrastructure.Contracts;

namespace Visma.SecureCoding.Logic.Contracts.SensitiveDataExposure
{
    public interface IStoreHashedPasswordCommandHandler : ICommandHandler<IStorePasswordCommand, string>
    {
    }
}