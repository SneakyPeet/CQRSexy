using Cqrsexy.Core;
using Cqrsexy.DomainMessages;

namespace Cqrsexy.Api
{
    class CommandDispatcher : ICommandDispatcher
    {
        private readonly ICommandHandlerFactory factory;

        public CommandDispatcher(ICommandHandlerFactory factory)
        {
            this.factory = factory;
        }

        public void Send<T>(T command) where T : ICommand
        {
            var handler = this.factory.Create(command);
            handler.Handle(command);
            this.factory.Destroy(handler);
        }
    }
}