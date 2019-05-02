using Visma.SecureCoding.Infrastructure.Contracts;

namespace Visma.SecureCoding.Logic.Contracts.SensitiveDataExposure
{
    public interface IStoreSecuredPasswordCommandHandler : ICommandHandler<IStorePasswordCommand, string>
    {
    }
}