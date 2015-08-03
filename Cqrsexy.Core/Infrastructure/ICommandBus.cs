using Cqrsexy.Commands;

namespace Cqrsexy.Core.Infrastructure
{
    public interface ICommandBus
    {
        void Submit<T>(T command) where T :ICommand;
    }

    
}