using System;
using System.Collections.Generic;
using System.Linq;
using Cqrsexy.Core.Infrastructure;
using Cqrsexy.Events;
using NUnit.Framework;

using Cqrsexy.Events;

namespace Cqrsexy.Tests
{
    [TestFixture]
    public abstract class SpesificationBase
    {
        [SetUp]
        public void SetUp()
        {
            Given();
            When();
        }

        protected virtual void Given() { }
        protected virtual void When() { }
    }

    public class TestRepo<T> : IRepository<T> where T : Aggregate {
        public TestRepo()
        {
            this.changes = new List<IEvent>();
        }
        public T GetById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public void Save(T aggregate)
        {
            changes = aggregate.GetUncommitedEvents().ToList();
        }

        private List<IEvent> changes;

        
    }


}
