using BCrypt.Net;
using System;
using Visma.SecureCoding.Logic.Contracts.SensitiveDataExposure;

namespace Visma.SecureCoding.Logic.SensitiveDataExposure
{
    public class SecureSensitiveData : ISecureSensitiveData
    {
        #region Methods

        public string ComputeHash(string value)
        { 
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));

            return BCrypt.Net.BCrypt.HashPassword(value);
        }

        #endregion
    }
}