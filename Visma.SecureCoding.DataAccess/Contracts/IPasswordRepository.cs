namespace Visma.SecureCoding.DataAccess.Contracts
{
    public interface IPasswordRepository
    {
        void StorePassword(string password);
    }
}