using System;
using System.Collections.Generic;
using Cqrsexy.Core;
using Cqrsexy.DomainMessages;

namespace Cqrsexy.Domain.Tests
{
    public class TestEventStore : ITestEventStore
    {
        private readonly Dictionary<Guid, Aggregate> aggregatesStore;

        public TestEventStore()
        {
            this.aggregatesStore = new Dictionary<Guid, Aggregate>();
        }

        public T Load<T>(Guid id) where T : Aggregate, new()
        {
            if (this.aggregatesStore.ContainsKey(id))
            {
                return (T)this.aggregatesStore[id];
            }
            throw new TestException(string.Format("Aggregate Id {0} cannot be found in the test event store", id));
        }

        public void Save(IEnumerable<Aggregate> aggregates)
        {
            throw new NotImplementedException();
        }

        public void CommitInitialEvents()
        {
            throw new NotImplementedException();
        }

        public List<IEvent> NewEvents()
        {
            throw new NotImplementedException();
        }
    }
}