using Cqrsexy.DomainMessages;

namespace Cqrsexy.Api
{
    public interface ICommandBus
    {
        void Submit<T>(T command) where T : ICommand;
    }
}