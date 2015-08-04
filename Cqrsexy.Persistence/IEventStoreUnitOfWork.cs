using System;
using Cqrsexy.Core;

namespace Cqrsexy.Persistence
{
    public interface IEventStoreUnitOfWork : IUnitOfWork
    {
        void RegisterForTracking(Aggregate aggregate);
        T GetById<T>(Guid id) where T : Aggregate;
        bool Contains(Guid id);
    }
}