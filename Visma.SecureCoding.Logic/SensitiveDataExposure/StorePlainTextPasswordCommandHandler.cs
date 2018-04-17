using System;
using Visma.SecureCoding.DataAccess.Contracts;
using Visma.SecureCoding.Logic.Contracts.SensitiveDataExposure;

namespace Visma.SecureCoding.Logic.SensitiveDataExposure
{
    public class StorePlainTextPasswordCommandHandler : IStorePlainTextPasswordCommandHandler
    {
        #region Private variables

        private readonly IPasswordRepository _passwordRepository;

        #endregion

        #region Constructors

        public StorePlainTextPasswordCommandHandler(IPasswordRepository passwordRepository)
        {
            if (passwordRepository == null) throw new ArgumentNullException(nameof(passwordRepository));

            _passwordRepository = passwordRepository;
        }

        #endregion

        #region Methods

        public string Execute(IStorePasswordCommand storePasswordCommand)
        {
            if (storePasswordCommand == null) throw new ArgumentNullException(nameof(storePasswordCommand));

            string passwordToStore = storePasswordCommand.PasswordToStore;
            _passwordRepository.StorePassword(passwordToStore);

            return passwordToStore;
        }

        #endregion
    }
}