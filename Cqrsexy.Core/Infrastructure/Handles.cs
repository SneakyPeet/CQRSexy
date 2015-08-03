using Cqrsexy.Commands;

namespace Cqrsexy.Core.Infrastructure
{
    public interface Handles<in T> where T : ICommand
    {
        void Handle(T cmd);
    }
}