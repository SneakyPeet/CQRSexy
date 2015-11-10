using System.Collections.Generic;
using Cqrsexy.Api;
using Cqrsexy.Domain.Tests.MockEventStore;
using Cqrsexy.DomainMessages;
using NUnit.Framework;
using SharpTestsEx;

namespace Cqrsexy.Domain.Tests
{
    [TestFixture]
    public abstract class Spesification
    {
        protected Spesification()
        {
            var container = FixtureBase.Container;
            app = container.Resolve<IApplication>();
            eventStore = container.Resolve<TestEventStore>();
        }

        protected readonly IApplication app;
        protected readonly TestEventStore eventStore;

        protected void And<T>(T command) where T : ICommand
        {
            Given<T>(command);
        }

        protected void Given<T>(T command) where T : ICommand
        {
            this.app.Execute<T>(command);
            this.eventStore.CommitInitialEvents();
        }

        protected void When<T>(T command) where T : ICommand
        {
            this.app.Execute<T>(command);
        }

        protected void Then(IEnumerable<IEvent> expectedEvents)
        {
            this.eventStore.NewEvents().Should()
                      .Not.Be.Empty()
                      .And.Have.SameSequenceAs(expectedEvents)
                      .And.Have.UniqueValues();
        }

        protected void ThenNoEvents()
        {
            this.eventStore.NewEvents().Should()
                .Be.Empty();
        }

        [TearDown]
        public void TearDown()
        {
            eventStore.Complete();
        }
    }
}