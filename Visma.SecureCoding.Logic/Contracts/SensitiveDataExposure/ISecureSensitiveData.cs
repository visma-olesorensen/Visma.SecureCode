namespace Visma.SecureCoding.Logic.Contracts.SensitiveDataExposure
{
    public interface ISecureSensitiveData
    {
        string SecureData(string value);
    }
}