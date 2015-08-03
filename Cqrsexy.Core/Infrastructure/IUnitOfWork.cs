namespace Cqrsexy.Core.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}