using Cqrsexy.DomainMessages;

namespace Cqrsexy.Api
{
    public interface ICommandDispatcher
    {
        void Send<T>(T command) where T : ICommand;
    }
}