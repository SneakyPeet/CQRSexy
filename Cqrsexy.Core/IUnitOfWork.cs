namespace Cqrsexy.Core
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}