using Cqrsexy.DomainMessages;

namespace Cqrsexy.Core
{
    public interface Handles<in T> where T : ICommand
    {
        void Handle(T cmd);
    }
}