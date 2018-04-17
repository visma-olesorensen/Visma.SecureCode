namespace Visma.SecureCoding.Logic.Contracts.SensitiveDataExposure
{
    public interface ISecureSensitiveData
    {
        string ComputeHash(string value);
    }
}