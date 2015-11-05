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

        protected ITestEventStore eventStore;
        private IApplication application;

        [SetUp]
        public void SetUp()
        {
            foreach(var command in this.Given())
            {
                this.application.Execute(command);
                this.eventStore.CommitInitialEvents();
            }
        }

        protected void Execute()
        {
            this.application.Execute(this.When());
        }
    }
}