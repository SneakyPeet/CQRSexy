using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Cqrsexy.Core;
using Cqrsexy.Persistence;

namespace Cqrsexy.Api.Windsor
{
    public class ApplicationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromAssemblyNamed("Cqrsexy.Domain")
                .BasedOn(typeof(ICommandHandler<>))
                .WithServiceAllInterfaces()
                .LifestyleTransient()
            );

            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                Component.For<ICommandHandlerFactory>()
                    .AsFactory()
                    .LifestyleSingleton()
                );

            container.Register(
                Component.For<IApplication>()
                .ImplementedBy<ApplicationHandlingUnitOfWork>()
                .LifestyleTransient()
            );

            container.Register(
                Component.For<ICommandDispatcher>()
                .ImplementedBy<CommandDispatcher>()
                .LifestyleTransient()
            );

            container.Register(
                Component.For<IRepository>()
                .ImplementedBy<EventStoreRepository>()
                .LifestyleTransient()
            );

            //unit of work needs to resolved by calling application
        }
    }
}
