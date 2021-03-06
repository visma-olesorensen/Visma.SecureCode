using System;
using Visma.SecureCoding.DataAccess.Contracts;
using Visma.SecureCoding.Logic.Contracts.SensitiveDataExposure;

namespace Visma.SecureCoding.Logic.SensitiveDataExposure
{
    public class StoreSecuredPasswordCommandHandler : IStoreSecuredPasswordCommandHandler
    {
        #region Private variables

        private readonly IPasswordRepository _passwordRepository;
        private readonly ISecureSensitiveData _secureSensitiveData;

        #endregion

        #region Constructors

        public StoreSecuredPasswordCommandHandler(IPasswordRepository passwordRepository, ISecureSensitiveData secureSensitiveData)
        {
            if (passwordRepository == null) throw new ArgumentNullException(nameof(passwordRepository));
            if (secureSensitiveData == null) throw new ArgumentNullException(nameof(secureSensitiveData));

            _passwordRepository = passwordRepository;
            _secureSensitiveData = secureSensitiveData;
        }

        #endregion

        #region Methods

        public string Execute(IStorePasswordCommand storePasswordCommand)
        {
            if (storePasswordCommand == null) throw new ArgumentNullException(nameof(storePasswordCommand));

            string passwordToStore = _secureSensitiveData.SecureData(storePasswordCommand.PasswordToStore);
            _passwordRepository.StorePassword(passwordToStore);

            return passwordToStore;
        }

        #endregion
    }
}