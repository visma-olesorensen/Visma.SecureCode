using System;
using Visma.SecureCoding.Logic.Contracts.SensitiveDataExposure;

namespace Visma.SecureCoding.Logic.SensitiveDataExposure
{
    public class StorePasswordCommand : IStorePasswordCommand
    {
        #region Constructors

        public StorePasswordCommand(string passwordToStore)
        {
            if (string.IsNullOrWhiteSpace(passwordToStore)) throw new ArgumentNullException(nameof(passwordToStore));

            PasswordToStore = passwordToStore;
        }

        #endregion

        #region Properties

        public string PasswordToStore
        { 
            get;
            private set;
        }

        #endregion
    }
}