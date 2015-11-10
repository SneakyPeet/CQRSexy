using System;
using System.Collections.Generic;
using System.Linq;
using Cqrsexy.DomainMessages;

namespace Cqrsexy.Domain.Tests.MockEventStore
{
    public class TestEventStore : Dictionary<Guid, EventStream>
    {
        public void CommitInitialEvents()
        {
            var events = this.SelectMany(x => x.Value.Events);
            foreach(var evt in events)
            {
                evt.Commit();
            }
        }

        public List<IEvent> NewEvents()
        {
            return this.SelectMany(x => x.Value.Events)
                .Where(x => !x.IsCommitted)
                .Select(x => x.Event)
                .ToList();
        }

        public void Complete()
        {
            this.Clear();
        }
    }
}