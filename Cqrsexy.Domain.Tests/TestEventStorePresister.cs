using System;
using System.Collections.Generic;
using Cqrsexy.Core;
using Cqrsexy.Persistence;

namespace Cqrsexy.Domain.Tests
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
                if(eventStore.ContainsKey(aggregate.Id))
                {
                    eventStore.Remove(aggregate.Id);
                }
                eventStore.Add(aggregate.Id, aggregate);
            }
        }
    }
}