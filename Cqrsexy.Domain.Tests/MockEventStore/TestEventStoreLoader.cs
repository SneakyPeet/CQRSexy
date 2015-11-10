using System;
using Cqrsexy.Core;
using Cqrsexy.Persistence;

namespace Cqrsexy.Domain.Tests.MockEventStore
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
                return BuildAggregateFromHistory<T>(id);
            }
            throw new TestException(string.Format("Aggregate Id {0} cannot be found in the test event store", id));
        }

        private T BuildAggregateFromHistory<T>(Guid id) where T : Aggregate, new()
        {
            var stream = this.eventStore[id];
            var type = Type.GetType(stream.AggregateName);
            var aggregate = (T)Activator.CreateInstance(type);
            aggregate.LoadFromHistory(stream.History());
            return aggregate;
        }
    }
}