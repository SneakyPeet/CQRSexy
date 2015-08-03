using System;
using System.Collections.Generic;
using Cqrsexy.Core.Infrastructure;
using Cqrsexy.Events;
using NUnit.Framework;

namespace Cqrsexy.Tests
{
    [TestFixture]
    public abstract class AggregateSpesificationBase<T> where T : Aggregate, new()
    {
        protected T aggregate;
        protected Exception expectedException;
        protected IEnumerable<IEvent> changes;
        protected virtual IEnumerable<IEvent> Given
        {
            get
            {
                return new List<IEvent>();
            }
        }

        protected abstract void When();

        [ExecuteTest]
        public void ExecuteTest()
        {
            aggregate = new T();
            aggregate.LoadFromHistory(Given);
            try
            {
                When();
                changes = aggregate.GetUncommitedChanges();
            }
            catch(Exception e)
            {
                expectedException = e;
            }
        }

    }

    public class Then : TestAttribute {}

    public class ExecuteTest : SetUpAttribute { }

}
