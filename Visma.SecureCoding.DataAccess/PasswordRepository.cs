using System;
using Visma.SecureCoding.DataAccess.Contracts;

namespace Visma.SecureCoding.DataAccess
{
    public class PasswordRepository : IPasswordRepository
    {
        #region Methods

        public void StorePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException(nameof(password));

            // Store the password in a given context.
        }

        #endregion
    }
}