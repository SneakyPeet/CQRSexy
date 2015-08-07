using Cqrsexy.DomainMessages;

namespace Cqrsexy.Core
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        void Handle(T cmd);
    }
}