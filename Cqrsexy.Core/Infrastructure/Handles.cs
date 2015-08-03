using Cqrsexy.Commands;

namespace Cqrsexy.Core.Infrastructure
{
    public interface Handles<in T> : ICommandHandler where T : ICommand
    {
        void Handle(T cmd);
    }

    public interface ICommandHandler
    {
        
    }
}