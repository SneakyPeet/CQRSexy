using Cqrsexy.Core;
using Cqrsexy.DomainMessages;

namespace Cqrsexy.Api
{
    class CommandBus : ICommandBus
    {
        private readonly ICommandHandlerFactory factory;

        public CommandBus(ICommandHandlerFactory factory)
        {
            this.factory = factory;
        }

        public void Submit<T>(T command) where T : ICommand
        {
            var handler = this.factory.Create(command);
            handler.Handle(command);
            this.factory.Destroy(handler);
        }
    }
}