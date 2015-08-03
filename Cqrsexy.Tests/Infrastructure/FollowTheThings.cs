using System;
using System.Collections.Generic;
using Cqrsexy.Commands;
using Cqrsexy.Core.Infrastructure;
using Cqrsexy.Core.LeaveApplication;
using Cqrsexy.Events;
using Cqrsexy.Persistence;
using NUnit.Framework;
using SharpTestsEx;

namespace Cqrsexy.Tests.Infrastructure
{
    public class FollowTheThings
    {
        [Test]
        public void foo()
        {
            var uowf = new TestUnitOfWorkFactory();
            var app = new CqrsexyApi(uowf, new TestCommandBus((IEventStoreUnitOfWork)uowf.Make()));

            var command = new CreateLeaveEntry(new Guid(), DateTime.Now, DateTime.Now.AddDays(5), "foo");
            app.Handle(command);
        }
        
        public class TestCommandBus : ICommandBus
        {
            private LeaveApplicationApi api;
            public TestCommandBus(IEventStoreUnitOfWork uow)
            {
                api = new LeaveApplicationApi(new EventStoreRepository(uow, new TestEventStoreLoader()), null);
            }
            public void Submit<T>(T command) where T : ICommand
            {
                //resolve some how
                var foo = command as CreateLeaveEntry;
                api.Handle(foo);
            }
        }

        public class TestUnitOfWorkFactory : IUnitOfWorkFactory
        {
            private IUnitOfWork uow;
            public TestUnitOfWorkFactory()
            {
                uow = new EventStoreUnitOfWork(new TestEventStorePresister());
            }
            public IUnitOfWork Make()
            {
                return uow;
            }
        }

        public class TestEventStoreLoader : IEventStoreLoader
        {
            public T Load<T>(Guid id) where T : Aggregate, new()
            {
                return new T();
            }
        }

        public class TestEventStorePresister : IEventStorePresister
        {
            public void Save(List<Aggregate> aggregates)
            {
                var changes = new List<IEvent>();
                aggregates.ForEach(a => changes.AddRange(a.GetUncommitedChanges()));
            }
        }
    }
}