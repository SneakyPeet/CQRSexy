using System;
using System.Collections.Generic;
using System.Linq;
using Cqrsexy.Core;

namespace Cqrsexy.Persistence
{
    public class EventStoreUnitOfWork : IEventStoreUnitOfWork
    {
        private readonly Dictionary<Guid, Aggregate> trackedAggregates;
        private readonly IEventStorePresister eventStore;
        public EventStoreUnitOfWork(IEventStorePresister eventStore)
        {
            this.eventStore = eventStore;
            this.trackedAggregates = new Dictionary<Guid, Aggregate>();
        }

        public void RegisterForTracking(Aggregate aggregate)
        {
            if (trackedAggregates.ContainsKey(aggregate.Id))
            {
                throw new AggregateAlreadyAddedToUnitOfWork();
            }
            this.trackedAggregates.Add(aggregate.Id, aggregate);
        }

        public T GetById<T>(Guid id) where T : Aggregate
        {
            if(trackedAggregates.ContainsKey(id))
            {
                return (T)trackedAggregates[id];
            }
            return null;
        }
        
        public void Commit()
        {
            eventStore.Save(trackedAggregates.Values);
            foreach(var aggregate in trackedAggregates)
            {
                aggregate.Value.Commit();
            }
        }

        public void Rollback()
        {
            this.trackedAggregates.Clear();
        }
    }
}