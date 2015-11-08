using System;
using Cqrsexy.Core;
using Cqrsexy.Persistence;

namespace Cqrsexy.Domain.Tests
{
    public class TestEventStoreLoader : IEventStoreLoader
    {
        private readonly TestEventStore eventStore;

        public TestEventStoreLoader(TestEventStore eventStore)
        {
            this.eventStore = eventStore;
        }

        public T Load<T>(Guid id) where T : Aggregate, new()
        {
            if (this.eventStore.ContainsKey(id))
            {
                return (T)this.eventStore[id];
            }
            throw new TestException(string.Format("Aggregate Id {0} cannot be found in the test event store", id));
        }
    }
}