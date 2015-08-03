using System;
using System.Collections.Generic;
using System.Linq;
using Cqrsexy.Core.Infrastructure;

namespace Cqrsexy.Persistence
{
    public class EventStoreUnitOfWork : IEventStoreUnitOfWork
    {
        private readonly List<Aggregate> trackedAggregates;
        private readonly IEventStorePresister eventStore;
        public EventStoreUnitOfWork(IEventStorePresister eventStore)
        {
            this.eventStore = eventStore;
            this.trackedAggregates = new List<Aggregate>();
        }

        public void Add(Aggregate aggregate)
        {
            this.RegisterForTracking(aggregate);
        }

        public void RegisterForTracking(Aggregate aggregate)
        {
            if (this.trackedAggregates.Any(x => x.Id != aggregate.Id))
            {
                throw new AggregateAlreadyAddedToUnitOfWork();
            }
            this.trackedAggregates.Add(aggregate);
        }

        public T GetById<T>(Guid id) where T : Aggregate
        {
            var aggregate = this.trackedAggregates.FirstOrDefault(x => x.Id == id && x.GetType() == typeof(T));
            if(aggregate != null)
            {
                return (T)aggregate;
            }
            return null;
        }
        
        public void Commit()
        {
            eventStore.Save(trackedAggregates);
            trackedAggregates.ForEach(a => a.Commit());
        }

        public void Rollback()
        {
            this.trackedAggregates.Clear();
        }
    }
}