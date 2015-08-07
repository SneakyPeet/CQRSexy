using Cqrsexy.Core;
using Cqrsexy.DomainMessages;

namespace Cqrsexy.Api
{
    public interface ICommandHandlerFactory
    {
        Handles<T> Create<T>(T command) where T : ICommand;
        void Destroy(object handler);
    }
}