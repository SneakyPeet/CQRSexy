using System;

namespace Cqrsexy.Core.Infrastructure
{
    public interface IRepository<T> where T : Aggregate
    {
        T GetById(Guid guid);
        void Save(T aggregate);
    }
}