using System;

namespace Cqrsexy.Core.Infrastructure
{
    public interface IRepository
    {
        T GetById<T>(Guid id) where T : Aggregate;
        void Add(Aggregate aggregate);
    }
}