using System;

namespace Cqrsexy.Core
{
    public interface IRepository
    {
        T GetById<T>(Guid id) where T : Aggregate, new();
        void Add(Aggregate aggregate);
    }
}