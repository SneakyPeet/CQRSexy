using System;

namespace Cqrsexy.Core.Infrastructure
{
    public interface IEventStoreUnitOfWork : IUnitOfWork
    {
        void Add(Aggregate aggregate);
        void RegisterForTracking(Aggregate aggregate);
        T GetById<T>(Guid id) where T : Aggregate;
    }
}