using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Castle.Windsor;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Cqrsexy.Api;
using Cqrsexy.Core;
using Cqrsexy.DomainMessages;
using SharpTestsEx;

namespace Cqrsexy.Architecture.Tests
{
    [TestFixture]
    public class CommandHandlerFactoryTests
    {
        [Test]
        public void CommandHandlerFactoryResolvedThroughWindsorShouldCreateCorrectCommandHandlers()
        {
            var container = new WindsorContainer();
            container.Register(Classes.FromThisAssembly()
                .BasedOn(typeof(ICommandHandler<>))
                .WithServiceAllInterfaces());

            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                Component.For<ICommandHandlerFactory>()
                    .AsFactory()
                );

            var factory = container.Resolve<ICommandHandlerFactory>();
            var command = new TestCommand();

            var handler = factory.Create(command);

            handler.Should().Not.Be.Null();
            handler.Should().Be.InstanceOf<TestCommandHandler>();
            
        }
        
    }

    public class TestCommandHandler : ICommandHandler<TestCommand>
    {
        public void Handle(TestCommand cmd)
        {

        }
    }

    public class TestCommand : ICommand { }
}
