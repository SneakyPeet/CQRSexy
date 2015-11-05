using System.Collections.Generic;
using Cqrsexy.DomainMessages;
using Cqrsexy.Persistence;

namespace Cqrsexy.Domain.Tests
{
    public interface ITestEventStore : IEventStoreLoader, IEventStorePresister
    {
        void CommitInitialEvents();

        List<IEvent> NewEvents();
    }
}