using System.Collections.Generic;
using Cqrsexy.Api;
using Cqrsexy.DomainMessages;
using NUnit.Framework;

namespace Cqrsexy.Domain.Tests
{
    [TestFixture]
    public abstract class SpesificationBase
    {
        public abstract List<ICommand> Given();
        public abstract ICommand When();

        [Test]
        public abstract void Test();

        protected SpesificationBase()
        {
            var container = FixtureBase.Container;
            app = container.Resolve<IApplication>();
            eventStore = container.Resolve<TestEventStore>();
        }

        protected readonly IApplication app;
        protected readonly TestEventStore eventStore;

        [SetUp]
        public void SetUp()
        {
            foreach(var command in this.Given())
            {
                this.app.Execute(command);
                this.eventStore.CommitInitialEvents();
            }
        }

        protected void Execute()
        {
            this.app.Execute(this.When());
        }

        [TearDown]
        public void TearDown()
        {
            eventStore.Complete();
        }
    }
}