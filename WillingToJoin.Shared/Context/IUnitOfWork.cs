namespace WillingToJoin.Shared.Context
{
    public interface IUnitOfWork
    {
        int Complete();
        void Dispose();
    }
}