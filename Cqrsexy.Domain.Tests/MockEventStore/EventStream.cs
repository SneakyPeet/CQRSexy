using System;
using System.Collections.Generic;
using System.Linq;
using Cqrsexy.Core;
using Cqrsexy.DomainMessages;

namespace Cqrsexy.Domain.Tests.MockEventStore
{
    public class EventStream
    {
        public EventStream(Aggregate aggregate)
        {
            this.AggregateName = aggregate.GetType().AssemblyQualifiedName;
            this.Id = aggregate.Id;
            this.Events = new List<EventStreamEvent>();
        }

        public Guid Id { get; private set; }
        public string AggregateName { get; private set; }
        public List<EventStreamEvent> Events { get; private set; }
        public void AddEvents(IEnumerable<IEvent> events)
        {
            this.Events.AddRange(events.Select(x => new EventStreamEvent(x)));
        }

        public IEnumerable<IEvent> History()
        {
            return this.Events.Select(x => x.Event);
        }
    }
}