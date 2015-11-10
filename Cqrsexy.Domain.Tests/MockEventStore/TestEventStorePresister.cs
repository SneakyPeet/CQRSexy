using System.Collections.Generic;
using Cqrsexy.Core;
using Cqrsexy.Persistence;

namespace Cqrsexy.Domain.Tests.MockEventStore
{
    public class TestEventStorePresister : IEventStorePresister
    {
        private readonly TestEventStore eventStore;

        public TestEventStorePresister(TestEventStore eventStore)
        {
            this.eventStore = eventStore;
        }

        public void Save(IEnumerable<Aggregate> aggregates)
        {
            foreach(var aggregate in aggregates)
            {
                EventStream eventStream;
                if(this.eventStore.ContainsKey(aggregate.Id))
                {
                    eventStream = this.eventStore[aggregate.Id];
                }
                else
                {
                    eventStream = new EventStream(aggregate);
                    this.eventStore.Add(eventStream.Id, eventStream);
                }
                eventStream.AddEvents(aggregate.GetUncommitedChanges());
            }
        }
    }
}