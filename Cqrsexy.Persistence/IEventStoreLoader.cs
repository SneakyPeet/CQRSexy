using System;
using Cqrsexy.Core;

namespace Cqrsexy.Persistence
{
    public interface IEventStoreLoader
    {
        T Load<T>(Guid id) where T: Aggregate, new();
    }
}