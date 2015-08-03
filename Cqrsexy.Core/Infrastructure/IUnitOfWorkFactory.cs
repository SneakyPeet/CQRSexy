namespace Cqrsexy.Core.Infrastructure
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Make();
    }
}