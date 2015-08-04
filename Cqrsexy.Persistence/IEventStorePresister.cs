using System.Collections.Generic;
using Cqrsexy.Core;

namespace Cqrsexy.Persistence
{
    public interface IEventStorePresister
    {
        void Save(IEnumerable<Aggregate> aggregates);
    }
}