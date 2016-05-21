namespace StupigShop.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}