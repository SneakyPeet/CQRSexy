using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Cqrsexy.Api.Windsor;
using Cqrsexy.Core;
using Cqrsexy.Domain.Tests.MockEventStore;
using Cqrsexy.Persistence;
using NUnit.Framework;

namespace Cqrsexy.Domain.Tests
{
    [SetUpFixture]
    public class FixtureBase
    {
        public static WindsorContainer Container { get; private set; }

        [SetUp]
	    public void RegisterContainer()
        {
            Container = new WindsorContainer();
            
            Container.Install(
                new ApplicationInstaller()
            );

            Container.Register(
                Component.For<IEventStorePresister>()
                         .ImplementedBy<TestEventStorePresister>()
                         .LifestyleTransient()
                );

            Container.Register(
                Component.For<IEventStoreLoader>()
                         .ImplementedBy<TestEventStoreLoader>()
                         .LifestyleTransient()
                );

            Container.Register(
                Component.For<TestEventStore>()
                );

            Container.Register(
                Component.For<IUnitOfWork, IEventStoreUnitOfWork>()
                .ImplementedBy<EventStoreUnitOfWork>()
                .LifestyleSingleton()
            );
        }

        [TearDown]
	    public void DestroyContainer()
	    {
	        Container.Dispose();
            Container = null;
	    }
    }
}
