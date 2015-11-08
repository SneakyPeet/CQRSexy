using System;
using System.Collections.Generic;
using System.Linq;
using Cqrsexy.Core;
using Cqrsexy.DomainMessages;

namespace Cqrsexy.Domain.Tests
{
    public class TestEventStore : Dictionary<Guid, Aggregate>
    {
        public void CommitInitialEvents()
        {
            foreach(var aggregate in this.Values)
            {
                aggregate.Commit();
            }
        }

        public List<IEvent> NewEvents()
        {
            return this.Values.SelectMany(x => x.GetUncommitedChanges()).ToList();
        }

        public void Complete()
        {
            this.Clear();
        }
    }
}