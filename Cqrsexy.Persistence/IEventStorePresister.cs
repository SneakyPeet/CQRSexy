using System.Collections.Generic;
using Cqrsexy.Core.Infrastructure;

namespace Cqrsexy.Persistence
{
    public interface IEventStorePresister
    {
        void Save(List<Aggregate> aggregates);
    }
}