using Cqrsexy.Core;
using Cqrsexy.DomainMessages;

namespace Cqrsexy.Api
{
    class CommandBus : ICommandBus
    {
        private readonly ICommandHandlerContainer container;

        public CommandBus(ICommandHandlerContainer container)
        {
            this.container = container;
        }

        public void Submit<T>(T command) where T : ICommand
        {
            Handles<T> handler = container.Resolve<T>();
            handler.Handle(command);
        }
    }
}